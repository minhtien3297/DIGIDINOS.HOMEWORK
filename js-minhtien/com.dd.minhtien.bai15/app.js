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
product2.saleDate = new Date(2021, 0, 18, 0, 0, 0, 0);
product2.quality = 0;
product2.isDeleted = true;

product3 = new Product();
product3.id = 3;
product3.name = "dao";
product3.categoryId = 3;
product3.saleDate = new Date(2021, 0, 15, 0, 0, 0, 0);
product3.quality = 20;
product3.isDeleted = false;

//Khoi tao list
var listProduct = [];

listProduct[0] = product1;
listProduct[1] = product2;
listProduct[2] = product3;

/**
 * Check product with category id by for loop
 * @param {Array} listProduct
 * @param {number} categoryId
 * @return {boolean}
 */
function isHaveProductInCategoryByFor(listProduct, categoryId) {
  var check = 0;

  for (var i = 0; i < listProduct.length; i++) {
    if (listProduct[i].categoryId == categoryId) {
      check++;
    }
  }

  if (check > 0) {
    return true;
  } else return false;
}

/**
 * Check product with category id by Es6
 * @param {Array} listProduct
 * @param {number} categoryId
 * @returns{boolean}
 */
function isHaveProductInCategoryByEs6(listProduct, categoryId) {
  var check = 0;

  listProduct.forEach((element) => {
    if (element.categoryId == categoryId) {
      check++;
    }
  });

  if (check > 0) {
    return true;
  } else return false;
}

//Kiem tra
console.log(isHaveProductInCategoryByFor(listProduct, 1));

console.log(isHaveProductInCategoryByEs6(listProduct, 4));
