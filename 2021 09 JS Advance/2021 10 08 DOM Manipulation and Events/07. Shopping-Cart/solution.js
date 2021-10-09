function solve() {
   document.getElementsByClassName('shopping-cart')[0].addEventListener('click', onClick);
   let totalPrice = 0;
   let uniqueProducts = [];
   let textArea = document.getElementsByTagName('textarea')[0];

   function onClick(event) {
      if (event.target.tagName == 'BUTTON' &&                //if click on type Button
         event.target.classList.contains('add-product')) { // becouse there are two type os buttons, we want to select only first kind
         const product = event.target.parentNode.parentNode;
         const productName = product.querySelector('.product-title').textContent;
         const productPrice = Number(product.querySelector('.product-line-price').textContent);

         if (!uniqueProducts.includes(productName)) {
            uniqueProducts.push(productName);
         }
         
         totalPrice += productPrice;
         textArea.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`
      }

      if (event.target.tagName == 'BUTTON' &&                //if click on type Button
         event.target.classList.contains('checkout')) { //checkout button
            textArea.textContent += `You bought ${uniqueProducts.join(', ')} for ${totalPrice.toFixed(2)}.`;
            document.getElementsByClassName('shopping-cart')[0].removeEventListener('click', onClick);
      }
   }
}