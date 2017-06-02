using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoTests.Tools.Refactroings.Entities;

namespace AutoTests.Tools.Refactroings.Infrastructure
{
    public class FeatureFileWriter
    {
        public void Write(IEnumerable<FeatureFile> featureFiles)
        {
            foreach (var featureFile in featureFiles)
            {
                WriteFeatureFile(featureFile);
            }
        }

        private void WriteFeatureFile(FeatureFile featureFile)
        {
            using (var stream = new StreamWriter(featureFile.File.FullName))
            {
                WriteFeature(featureFile.Feature, stream);
            }
        }

        private void WriteFeature(Feature feature, TextWriter writer)
        {
            foreach (var tag in feature.Tags)
            {
                writer.WriteLine(tag);
            }

            writer.WriteLine($"Feature: {feature.Name}");

            if (!string.IsNullOrEmpty(feature.Description))
            {
                writer.WriteLine(feature.Description);
            }

            foreach (var scenario in feature.Scenarios)
            {
                writer.WriteLine();
                WriteScenario(scenario, writer);
            }
        }

        private void WriteScenario(Scenario scenario, TextWriter writer)
        {

            foreach (var tag in scenario.Tags)
            {
                writer.WriteLine(tag);
            }

            if (scenario.Examples.Any())
            {
                writer.WriteLine($"Scenario Outline: {scenario.Name}");
            }
            else
            {
                writer.WriteLine($"Scenario: {scenario.Name}");
            }

            if (!string.IsNullOrEmpty(scenario.Description))
            {
                writer.WriteLine(scenario.Description);
            }

            StepType lastStepType = StepType.Given;
            for (var i = 0; i < scenario.Steps.Count; i++)
            {
                var step = scenario.Steps[i];
                WriteStep(step, writer, lastStepType, i == 0);
                lastStepType = step.StepType;
            }

            foreach (var example in scenario.Examples)
            {
                writer.WriteLine();
                writer.WriteLine("\tExamples:");

                var data = GetExamplesTableData(example);
                FormatColumnWidth(data);
                WriteTable(data, writer, "\t");
            }
        }

        private void WriteStep(Step step, TextWriter writer, StepType lastStepType, bool firstStep)
        {
            string prefix;
            if (!firstStep && lastStepType == step.StepType)
            {
                writer.WriteLine($"\t\tAnd {step.Text}");
                prefix = new string('\t', 2);
            }
            else
            {
                writer.WriteLine($"\t{step.StepType} {step.Text}");
                prefix = new string('\t', 1);
            }

            if (step.Table.Rows.Any())
            {
                var data = step.StepDefinition.IsEnumerableArgument()
                    ? GetHorizontalTableData(step.Table)
                    : GetVerticalTableData(step.Table);

                FormatColumnWidth(data);
                WriteTable(data, writer, prefix);
            }
        }

        private void WriteTable(string[][] data, TextWriter writer, string prefix)
        {
            foreach (var line in data)
            {
                writer.WriteLine($"{prefix}| {string.Join(" | ", line)} |");
            }
        }

        private void FormatColumnWidth(string[][] data)
        {
            for (int x = 0; x < data[0].Length; x++)
            {
                var length = data.Max(row => row[x].Length);

                for (int y = 0; y < data.Length; y++)
                {
                    if (data[y][x].Length < length)
                    {
                        data[y][x] = data[y][x] + new string(' ', length - data[y][x].Length);
                    }
                }
            }
        }

        private string[][] GetExamplesTableData(Examples examples)
        {
            var columns = GetExampleTableColumns(examples);

            string[][] data = new string[examples.Cases.Count + 1][];
            data[0] = columns;

            for (var y = 0; y < examples.Cases.Count; y++)
            {
                var row = examples.Cases[y];
                data[y + 1] = new string[columns.Length];

                foreach (var cell in row.Cells)
                {
                    var x = Array.FindIndex(columns, t => t == cell.Column);
                    data[y + 1][x] = cell.Value;
                }
            }

            return data;
        }
        
        private string[][] GetHorizontalTableData(Table table)
        {
            var columns = GetHorizontalTableColumns(table);

            string[][] data = new string[table.Rows.Count + 1][];
            data[0] = columns;

            for (var y = 0; y < table.Rows.Count; y++)
            {
                var row = table.Rows[y];
                data[y + 1] = new string[columns.Length];

                foreach (var item in row.Items)
                {
                    var x = Array.FindIndex(columns, t => t == item.Name);
                    data[y + 1][x] = item.Value;
                }
            }

            return data;
        }

        private string[][] GetVerticalTableData(Table table)
        {
            var row = table.Rows.Single();

            string[][] data = new string[row.Items.Count + 1][];
            var columns = GetVerticalTableColumns(row);
            data[0] = columns;

            for (var y = 0; y < row.Items.Count; y++)
            {
                var item = row.Items[y];
                data[y + 1] = new string[columns.Length];
                data[y + 1][0] = item.Name;
                data[y + 1][1] = item.Value;

                if (!string.IsNullOrEmpty(item.Attribute))
                {
                    data[y + 1][2] = item.Value;
                }
            }

            return data;
        }

        private string[] GetVerticalTableColumns(TableRow row)
        {
            if (row.Items.Any(x => !string.IsNullOrEmpty(x.Attribute)))
            {
                return new[]
                {
                    "Name",
                    "Value",
                    "Attribute"
                };
            }
            else
            {
                return new[]
                {
                    "Name",
                    "Value",
                };
            }
        }

        private string[] GetExampleTableColumns(Examples examples)
        {
            return examples.Cases.SelectMany(x => x.Cells.Select(y => y.Column)).Distinct().ToArray();
        }

        private string[] GetHorizontalTableColumns(Table table)
        {
            return table.Rows.SelectMany(x => x.Items.Select(y => y.Name)).Distinct().ToArray();
        }
    }
}