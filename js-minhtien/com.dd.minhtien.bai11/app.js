class Product {
  constructor(id, name, categoryId, saleDate, quality, isDeleted) {
    this.id = id;
    this.name = name;
    this.categoryId = categoryId;
    this.saleDate = saleDate;
    this.quality = quality;
    this.isDeleted = isDeleted;
  }
}

//Khoi tao doi tuong
product1 = new Product();
product1.id = 1;
product1.name = "tien";
product1.categoryId = 1;
product1.saleDate = new Date(2014, 0, 1, 0, 0, 0, 0);
product1.quality = 20;
product1.isDeleted = true;

product2 = new Product();
product2.id = 2;
product2.name = "minh";
product2.categoryId = 2;
product2.saleDate = new Date(2014, 0, 1, 0, 0, 0, 0);
product2.quality = 10;
product2.isDeleted = true;

//Khoi tao list
var listProduct = [];

listProduct[0] = product1;
listProduct[1] = product2;

/**
 * Get list by id using for loop
 * @param {Array} listProduct
 * @param {number} idProduct
 * @returns {Array} List
 */
function filterProductByIdByFor(listProduct, idProduct) {
  for (var i = 0; i < listProduct.length; i++) {
    if (listProduct[i].id == idProduct) {
      console.log(listProduct[i].name);
    }
  }
}

/**
 * Get list by id by for loop
 * @param {Array} listProduct
 * @param {number} idProduct
 * @returns{Array} List
 */
function filterProductByIdByEs6(listProduct, idProduct) {
  listProduct.forEach((element) => {
    if (element.id == idProduct) {
      console.log(element.name);
    }
  });
}

//Chay ham
filterProductByIdByFor(listProduct, 1);

filterProductByIdByEs6(listProduct, 2);
