Feature: Models

Scenario: transform vertial model
    Then model test step 1:
    | Name | Value        |
    | X    | @1+2         |
    | Y    | Hello World! |

Scenario: transform horizontal model
    Then model test step 2:
    | X    | Y            |
    | @1+2 | Hello World! |
    | 3    | @"x" + "y"   |