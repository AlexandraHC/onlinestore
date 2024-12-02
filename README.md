The aim of this project is to offer a base API (no front-end) for an online shop.

The starting point will be to create an account using an email address and a password.
For each account we can add multiple customers (persons, companies). Each customer should have an address.

An user should be able to navigate through categories, sort and filter the products and categories and see the products.
A product can be provided by one or multiple suppliers. Also, we will always know how many pieces of a product are in the stock.
Once, the user decides to buy a product, this can be added to the cart and the quantity can be updated.
Cart can be linked to an user but this is not mandatory, a cart can belong to an anonymous user who does not have an account and only navigates through the store.
Anytime, a registered user can place an order containing the products already added in the cart. 
The shop provides multiple payment methods and the customer can choose one of them.
When the order is confirmed, an invoice should be generated and the information about the payment is saved.

Possible scenarios:

Clicked on the cart button from homepage, listing page (category page and search page) the product is successfully added to cart.
Verify that the filter displays a complete list of product categories.
Test adding, updating, and removing items from the cart works as expected.
Increase/decrease the product quantity from the pages related: homepage, listing page, search page, cart page, the quantity is modified.
Ensure the search functionality returns relevant results.
Verify that a user can create an account by using an email address, an username and a password.
Verify that a user can create one or multiple customers linked to his account.
With an account created, go to login page by using email and password, the user is redirected to my account.
Verify that a user can logout successfully.
Test adding, updating, and removing items from the cart works as expected.
By going further from the cart page, validate the entire checkout process, including payment, order confirmation and invoice generation.

!! Small business logic changes can occur during the development !!


