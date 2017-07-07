
function findElement(locator) {
    return document.evaluate(locator, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
}

var locator = arguments[0];
return findElement(locator).value;