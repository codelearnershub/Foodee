// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
alert("Hi");


var cart = {
    // (A) PROPERTIES
 

    hPdt: null, // HTML products list
    hItems: null, // HTML current cart
    items: {}, // Current items in cart
    iURL: "images/", // Product image URL folder

    // (B) LOCALSTORAGE CART
    // (B1) SAVE CURRENT CART INTO LOCALSTORAGE
    save: function () {
        localStorage.setItem("cart", JSON.stringify(cart.items));
    },

    // (B2) LOAD CART FROM LOCALSTORAGE
    load: function () {
        cart.items = localStorage.getItem("cart");
        if (cart.items == null) { cart.items = {}; }
        else { cart.items = JSON.parse(cart.items); }
    },

    // (B3) EMPTY ENTIRE CART
    nuke: function () {
        if (confirm("Empty cart?")) {
            cart.items = {};
            localStorage.removeItem("cart");
            cart.list();
        }
    },


 

    init: function () {
        var products = document.getElementsByClassName("productlists");
        var addtocartbtn = document.getElementById('addtocartbtn');
        alert(addtocartbtn.innerHTML);
        // (C1) GET HTML ELEMENTS
         cart.hPdt = document.getElementById("cart-products");
         cart.hItems = document.getElementById("cart-items");

        // (C2) DRAW PRODUCTS LIST
        cart.hPdt.innerHTML = "";
        let p, item, part;
        for (let id in products) {




            // ADD TO CART
    /*
             par.className = "cart p-add";*/
            addtocartbtn.onclick = cart.add;
            alert(cart.items)
            addtocartbtn.dataset.id = id;
               item.appendChild(part);
        }
    

        // (C3) LOAD CART FROM PREVIOUS SESSION
        cart.load();

        // (C4) LIST CURRENT CART ITEMS
        cart.list();
    },



    list: function () {
        // (D1) RESET
        cart.hItems.innerHTML = "";
        let item, part, pdt;
        let empty = true;
        for (let key in cart.items) {
            if (cart.items.hasOwnProperty(key)) { empty = false; break; }
        }

        // (D2) CART IS EMPTY
        if (empty) {
            item = document.createElement("div");
            item.innerHTML = "Cart is empty";
            cart.hItems.appendChild(item);
        }

        // (D3) CART IS NOT EMPTY - LIST ITEMS
        else {
            let p, total = 0, subtotal = 0;
            for (let id in cart.items) {
                // ITEM
                p = products[id];
                item = document.createElement("div");
                item.className = "c-item";
                cart.hItems.appendChild(item);

                // NAME
                part = document.createElement("div");
                part.innerHTML = p.name;
                part.className = "c-name";
                item.appendChild(part);

                // REMOVE
                part = document.createElement("input");
                part.type = "button";
                part.value = "X";
                part.dataset.id = id;
                part.className = "c-del cart";
                part.addEventListener("click", cart.remove);
                item.appendChild(part);

                // QUANTITY
                part = document.createElement("input");
                part.type = "number";
                part.min = 0;
                part.value = cart.items[id];
                part.dataset.id = id;
                part.className = "c-qty";
                part.addEventListener("change", cart.change);
                item.appendChild(part);

                // SUBTOTAL
                subtotal = cart.items[id] * p.price;
                total += subtotal;
            }

            // TOTAL AMOUNT
            item = document.createElement("div");
            item.className = "c-total";
            item.id = "c-total";
            item.innerHTML = "TOTAL: $" + total;
            cart.hItems.appendChild(item);

            // EMPTY BUTTONS
            item = document.createElement("input");
            item.type = "button";
            item.value = "Empty";
            item.addEventListener("click", cart.nuke);
            item.className = "c-empty cart";
            cart.hItems.appendChild(item);

            // CHECKOUT BUTTONS
            item = document.createElement("input");
            item.type = "button";
            item.value = "Checkout";
            item.addEventListener("click", cart.checkout);
            item.className = "c-checkout cart";
            cart.hItems.appendChild(item);
        }
    },


    add: function () {
        if (cart.items[this.dataset.id] == undefined) {
            cart.items[this.dataset.id] = 1;
        } else {
            cart.items[this.dataset.id]++;
        }
        cart.save();
        cart.list();
    }
    
};

/*$(function () {
    $("#addtocartbtn").click(function () {
        alert("Hello");
        var value = document.getElementById("")
        localStorage.setItem("name",)
    });
});*/

window.addEventListener("DOMContentLoaded", cart.init);
