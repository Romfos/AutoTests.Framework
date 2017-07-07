
function findElement(locator) {
    return document.evaluate(locator, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
}

var locator = arguments[0];
var value = arguments[1];
findElement(locator).value = value;