export function getLocalOffsetminutes() {
    return new Date().getTimezoneOffset();
}

export function addToCart(productName) {
    alert(productName + " has been added to Cart")
}