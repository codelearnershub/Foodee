// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.
//alert("Hi");


//var cart = {
//     (A) PROPERTIES
 

//    hPdt: null, // HTML products list
//    hItems: null, // HTML current cart
//    items: {}, // Current items in cart
//    iURL: "images/", // Product image URL folder

//     (B) LOCALSTORAGE CART
//     (B1) SAVE CURRENT CART INTO LOCALSTORAGE
//    save: function () {
//        localStorage.setItem("cart", JSON.stringify(cart.items));
//    },

//     (B2) LOAD CART FROM LOCALSTORAGE
//    load: function () {
//        cart.items = localStorage.getItem("cart");
//        if (cart.items == null) { cart.items = {}; }
//        else { cart.items = JSON.parse(cart.items); }
//    },

//     (B3) EMPTY ENTIRE CART
//    nuke: function () {
//        if (confirm("Empty cart?")) {
//            cart.items = {};
//            localStorage.removeItem("cart");
//            cart.list();
//        }
//    },


 

//    init: function () {
//        var products = document.getElementsByClassName("productlists");
//        var addtocartbtn = document.getElementById('addtocartbtn');
//        alert(addtocartbtn.innerHTML);
//         (C1) GET HTML ELEMENTS
//         cart.hPdt = document.getElementById("cart-products");
//         cart.hItems = document.getElementById("cart-items");

//         (C2) DRAW PRODUCTS LIST
//        cart.hPdt.innerHTML = "";
//        let p, item, part;
//        for (let id in products) {




//             ADD TO CART
    
//             par.className = "cart p-add";
//            addtocartbtn.onclick = cart.add;
//            alert(cart.items)
//            addtocartbtn.dataset.id = id;
//               item.appendChild(part);
//        }
    

//         (C3) LOAD CART FROM PREVIOUS SESSION
//        cart.load();

//         (C4) LIST CURRENT CART ITEMS
//        cart.list();
//    },



//    list: function () {
//         (D1) RESET
//        cart.hItems.innerHTML = "";
//        let item, part, pdt;
//        let empty = true;
//        for (let key in cart.items) {
//            if (cart.items.hasOwnProperty(key)) { empty = false; break; }
//        }

//         (D2) CART IS EMPTY
//        if (empty) {
//            item = document.createElement("div");
//            item.innerHTML = "Cart is empty";
//            cart.hItems.appendChild(item);
//        }

//         (D3) CART IS NOT EMPTY - LIST ITEMS
//        else {
//            let p, total = 0, subtotal = 0;
//            for (let id in cart.items) {
//                 ITEM
//                p = products[id];
//                item = document.createElement("div");
//                item.className = "c-item";
//                cart.hItems.appendChild(item);

//                 NAME
//                part = document.createElement("div");
//                part.innerHTML = p.name;
//                part.className = "c-name";
//                item.appendChild(part);

//                 REMOVE
//                part = document.createElement("input");
//                part.type = "button";
//                part.value = "X";
//                part.dataset.id = id;
//                part.className = "c-del cart";
//                part.addEventListener("click", cart.remove);
//                item.appendChild(part);

//                 QUANTITY
//                part = document.createElement("input");
//                part.type = "number";
//                part.min = 0;
//                part.value = cart.items[id];
//                part.dataset.id = id;
//                part.className = "c-qty";
//                part.addEventListener("change", cart.change);
//                item.appendChild(part);

//                 SUBTOTAL
//                subtotal = cart.items[id] * p.price;
//                total += subtotal;
//            }

//             TOTAL AMOUNT
//            item = document.createElement("div");
//            item.className = "c-total";
//            item.id = "c-total";
//            item.innerHTML = "TOTAL: $" + total;
//            cart.hItems.appendChild(item);

//             EMPTY BUTTONS
//            item = document.createElement("input");
//            item.type = "button";
//            item.value = "Empty";
//            item.addEventListener("click", cart.nuke);
//            item.className = "c-empty cart";
//            cart.hItems.appendChild(item);

//             CHECKOUT BUTTONS
//            item = document.createElement("input");
//            item.type = "button";
//            item.value = "Checkout";
//            item.addEventListener("click", cart.checkout);
//            item.className = "c-checkout cart";
//            cart.hItems.appendChild(item);
//        }
//    },


//    add: function () {
//        if (cart.items[this.dataset.id] == undefined) {
//            cart.items[this.dataset.id] = 1;
//        } else {
//            cart.items[this.dataset.id]++;
//        }
//        cart.save();
//        cart.list();
//    }
    
//};

//$(function () {
//    $("#addtocartbtn").click(function () {
//        alert("Hello");
//        var value = document.getElementById("")
//        localStorage.setItem("name",)
//    });
//});

//window.addEventListener("DOMContentLoaded", cart.init);



// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const cartModal = $("#cart-modal");
const cartMenu = $("#cart-menu");
const totalQuantityLabel = $("#total-quantity-label");
const modalItemNameLabel = $("#item-name");
const modalItemPriceLabel = $("#item-price");
const modalItemQuantityInput = $("#quantity");
const modalItemTotalLabel = $("#item-total");
const checkoutTotalLabel = $("#checkoutTotalLabel");
const checkouQuantitytLabel = $("#checkouQuantitytLabel");
const modalItemPictureLabel = $("item-picture");
const checkoutItemTotalLabel = $("#item-total1");
const checkoutItemQuantityInput = $("#number");
const checkoutItemNameLabel = $("#item-name1");
const checkoutItemPriceLabel = $("#item-price1");
const modalMenu = $("#modal-menu");

function addToCart(itemHTMLElement) {

    const itemElement = $(itemHTMLElement);
    const price = parseInt(itemElement.attr("data-price"));

    const name = itemElement.attr("data-name");

    const itemId = itemElement.data("id");
    const itemPicture = itemElement.data("itemPicture");

    modalItemNameLabel.data("elementId", itemHTMLElement.id);
    modalItemNameLabel.html(name);
    modalItemPriceLabel.html(`Unit Price: ${price}`);
    modalItemPriceLabel.innerHTML = `Unit Price: ${price}`;
    modalItemPictureLabel.html(itemPicture);

    function onQuantityChanged() {
        let quantity = parseInt(this.value);
        if (isNaN(quantity)) {
            quantity = 0;
        }
        modalItemTotalLabel.html(`Total: : ${quantity * price}`);
    }

    modalItemQuantityInput.on("keyup", onQuantityChanged);
    modalItemQuantityInput.on("change", onQuantityChanged);

    setInitialQuantityAndTotalPrice(itemId, price);
    cartModal.modal("show");
}

function incrementQuantity(itemId) {
    changeQuantity(itemId, (quantity) => quantity + 1);
}

function decrementQuantity(itemId) {
    changeQuantity(itemId, (quantity) =>
        quantity > 0 ? quantity - 1 : quantity
    );
}

function changeQuantity(itemId, changeFunction) {
    const quantityInput = document.getElementById(`quantity_${itemId}`);
    const priceLabel = document.getElementById(`price_${itemId}`);
    const totalPriceLabel = document.getElementById(`totalPrice_${itemId}`);

    let quantity = parseInt(quantityInput.value);
    const price = parseFloat(priceLabel.innerHTML);

    quantity = isNaN(quantity) ? 0 : quantity;
    quantity = changeFunction(quantity);

    const totalPrice = quantity * price;

    totalPriceLabel.innerHTML = totalPrice;
    quantityInput.value = quantity;

    const cart = getCart();
    const item = { itemId, quantity };
    updateOrAddToCart(cart, item);
    updateCart(cart);
    updateCartMenu();
}

function setInitialQuantityAndTotalPrice(itemId) {
    const cart = getCart();
    const i = indexOfItemInCart(cart, itemId);
    if (i >= 0) {
        modalItemQuantityInput.val(cart[i].quantity + 1);
    } else {
        modalItemQuantityInput.val(1);
    }
    modalItemQuantityInput.trigger("change");
}

function indexOfItemInCart(cart, itemId) {
    for (const i in cart) {
        const cartItem = cart[i];

        if (cartItem.itemId === itemId) {
            return i;
        }
    }

    return -1;
}

function updateOrAddToCart(cart, item) {
    var i = indexOfItemInCart(cart, item.itemId);
    if (i < 0) {
        cart.push(item);
        return;
    }

    if (item.quantity == 0) {
        cart.splice(i, 1);
        return;
    }

    cart[i].quantity = item.quantity;
}

function getCart() {
    return JSON.parse(localStorage.getItem("cart")) || [];
}

//     $("#save").on("click", function () {
//         const elementId = modalItemNameLabel.data("elementId");
//     const itemElement = $(`#${elementId}`);
//     const itemId = itemElement.data("id");
//
//     console.log(`Adding to cart....`, itemId);
//    
//     const price = parseInt(itemElement.data("price"));
//     const name = itemElement.data("name");
//     const quantity = parseInt(modalItemQuantityInput.val());
//     const itemPicture = itemElement.data("itemPicture");
//
//     const item = { itemId, name, quantity, price, itemPicture };
//     const cart = getCart();
//     updateOrAddToCart(cart, item);
//     updateCart(cart);
//     updateCartMenu();
//     cartModal.modal("toggle");
// });

function saveToCart(isUserLoggedIn = "False") {
    const isUserLoggedInBool = isUserLoggedIn.toLocaleLowerCase() === "true";

    console.log("Is User Logged In", isUserLoggedInBool);

    const elementId = modalItemNameLabel.data("elementId");
    const itemElement = $(`#${elementId}`);
    const itemId = itemElement.data("id");
    const quantity = parseInt(modalItemQuantityInput.val());

    console.log(`Adding ${quantity} of item ${itemId} to cart....`);


    if (isUserLoggedInBool) {
        fetch(`/cart/AddToCart?id=${itemId}&count=${quantity}`)
            .then(res => res.json())
            .then(res => console.log(res));
    }
    else {

    }

}
function updateCart(cart) {
    localStorage.setItem("cart", JSON.stringify(cart));
}

function updateCartMenu() {
    const cart = getCart();

    let elements = `<table class="timetable_sub">
                            <thead class="">
                                <tr>
                                    
                                    <th>Product</th><br/>
                                    <th>Price</th><br/>
                                    <th>Quantity</th><br/>
                                    <th>Sub-Total</th><br/><br/>
                                    <th>Remove <i class="fas fa-trash-alt"></i></th>
                                </tr>
                            </thead>`;

    let totalPrice = 0;
    let tax = 0;
    let subTotalPrice = 0;
    cart.forEach((item) => {
        itemTotalPrice = item.quantity * item.price;

        subTotalPrice += itemTotalPrice;
        tax = subTotalPrice * 0.05;
        totalPrice = subTotalPrice + tax;


        elements += ` <tbody>
                        <tr class="rem1">

                            <td class="invert" id="item-name1">${item.name}</td>
                            <td class="invert" id="price_${item.id}">&#8358 ${item.price}</td>
                            <td class="invert text-dark">
                           
                                    <button onclick="decrementQuantity(${item.id})">-</button>
                                    <input class="text-center " style="width:40px" type="text" name="quantity" value="${item.quantity}" min="1" id="quantity_${item.id}" />
                                    <button onclick="incrementQuantity(${item.id})">+</button>
							
							</td>
                            <td class="invert" id="totalPrice_${item.id}">&#8358 ${subTotalPrice}</td>
                            <td class="invert"><div class="rem">
<button class="btn btn-sm btn-danger " onclick="deleteItemFromCart(${item.id}, getCart())"></span><i class="fas fa-trash-alt"></i></button></small>
                        </tr>     
                    </tbody>
            `;
    });

    elements += `</table>
                    <strong class="float-right text-success font-weight-bolder">Sub-total: &#8358 ${totalPrice}</strong><br/><br/>
   <div></div>
   <strong class="float-right text-success font-weight-bolder">Tax (5%): &#8358 ${tax}</strong>
    <div></div><br/>
   <strong class="float-right text-success font-weight-bolder">Total Price: &#8358 ${totalPrice}</strong> <p></p>`;

    elements += `<button class="btn btn-sm btn-danger"style="width: 50px" onclick="clearCart(getCart())">Empty Cart</button>`;

    // cartMenu.html(elements);
    var totalQuantity = getTotalQuantity();
    //totalQuantityLabel.html(totalQuantity);
    checkouQuantitytLabel.html(totalQuantity);
    checkoutTotalLabel.html(totalPrice);
    modalMenu.html(elements);
}

function getTotalQuantity() {
    const cart = getCart();
    let sum = 0;
    cart.forEach((item) => {
        sum += item.quantity;
    });
    return sum;
}

function clearCart() {
    const cart = [];
    updateCart(cart);
    updateCartMenu();
}

function deleteItemFromCart(itemId, cart) {
    const i = indexOfItemInCart(cart, itemId);
    if (i > -1) {
        cart.splice(i, 1);
    }
    updateCart(cart);
    updateCartMenu();
}

$(document).ready(function () {
    updateCartMenu();
    $('[data-toggle="popover"]').popover();
});
function closeModal() {
    cartModal.hide();
    location.reload();
}


