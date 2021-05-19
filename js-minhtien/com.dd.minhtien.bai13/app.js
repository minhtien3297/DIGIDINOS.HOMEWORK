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
product3.saleDate = new Date(2022, 0, 15, 0, 0, 0, 0);
product3.quality = 20;
product3.isDeleted = true;

//Khoi tao list
var listProduct = [];

listProduct[0] = product1;
listProduct[1] = product2;
listProduct[2] = product3;

//khoi tao list filter
var filterListProduct1 = [];
var filterListProduct2 = [];

//Khoi tao object lay ngay hien tai
var now = new Date();

/**
 * Get list with sale date > today and deleted by for loop
 * @param {Array} listProduct
 * @returns{Array} List
 */
function filterProductBySaleDateByFor(listProduct) {
  for (var i = 0; i < listProduct.length; i++) {
    if (listProduct[i].saleDate > Date.now() && listProduct[i].isDeleted) {
      filterListProduct1.push(listProduct[i].name);
    }
  }

  return filterListProduct1;
}

/**
 * Get list with sale date > today and deleted by Es6
 * @param {Array} listProduct
 * @returns{Array} List
 */
function filterProductBySaleDateByEs6(listProduct) {
  listProduct.forEach((element) => {
    if (element.saleDate > Date.now(0) && element.isDeleted) {
      filterListProduct2.push(element.name);
    }
  });
}

//Chay ham
filterProductBySaleDateByEs6(listProduct);

filterProductBySaleDateByFor(listProduct);

//Kiem tra
filterListProduct1.forEach((element) => {
  console.log(element);
});

filterListProduct2.forEach((element) => {
  console.log(element);
});
