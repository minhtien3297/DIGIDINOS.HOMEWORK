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

//Khoi tao object lay ngay hien tai
var now = new Date();

/**
 * Get list with sale date > today and not deleted by for loop
 * @param {Array} listProduct
 * @return {Array} List
 */
function filterProductBySaleDateByFor(listProduct) {
  var array = [];

  for (var i = 0; i < listProduct.length; i++) {
    if (listProduct[i].saleDate > Date.now() && listProduct[i].isDeleted) {
      array.push(listProduct[i]);
    }
  }

  return array;
}

/**
 * Get list with sale date > today and not deleted by Es6
 * @param {Array} listProduct
 * @return {Array} List
 */
function filterProductBySaleDateByEs6(listProduct) {
  var array = [];

  listProduct.forEach((element) => {
    if (element.saleDate > Date.now() && element.isDeleted) {
      array.push(element);
    }
  });

  return array;
}

/**
 * Get list with quality > 0 and deleted by for loop
 * @param {Array} listProduct
 * @param {Array} filterProductBySaleDateByFor
 * @returns{Array} List
 */
function filterProductByQualityByFor(
  listProduct,
  filterProductBySaleDateByFor
) {
  var array = [];

  for (var i = 0; i < listProduct.length; i++) {
    if (listProduct[i].quality > 0 && listProduct[i].isDeleted) {
      array.push(listProduct[i]);
    }
  }

  return filterProductBySaleDateByFor(array);
}

/**
 * Get list with quality > 0 and deleted by Es6
 * @param {Array} listProduct
 * @param {Array} filterProductBySaleDateByEs6
 * @returns{Array} List
 */
function filterProductByQualityByEs6(
  listProduct,
  filterProductBySaleDateByEs6
) {
  var array = [];

  listProduct.forEach((element) => {
    if (element.quality > 0 && element.isDeleted) {
      array.push(element);
    }
  });

  return filterProductBySaleDateByEs6(array);
}

/**
 * Get list with id and name by for loop
 * @param {Array} listProduct
 * @param {number} id
 * @param {string} name
 * @returns {Array} List
 */
function filterArrayStringByFor(listProduct, id, name) {
  var arrayString = [];

  for (var i = 0; i < listProduct.length; i++) {
    if (listProduct[i].id == id && listProduct[i].name == name) {
      arrayString.push(listProduct[i].id, listProduct[i].name);
    }
  }

  return arrayString;
}

/**
 * Get list with id and name by Es6
 * @param {Array} listProduct
 * @param {number} id
 * @param {string} name
 * @returns{Array} List
 */
function filterArrayStringByEs6(listProduct, id, name) {
  var arrayString = [];

  listProduct.forEach((element) => {
    if (element.id == id && element.name == name) {
      arrayString.push(element.id, element.name);
    }
  });

  return arrayString;
}

//Chay ham
var filterByEs6 = filterProductByQualityByEs6(
  listProduct,
  filterProductBySaleDateByEs6
);

var filterByFor = filterProductByQualityByFor(
  listProduct,
  filterProductBySaleDateByFor
);

//Kiem tra
console.log(filterArrayStringByFor(filterByFor, 1, "tien"));

console.log(filterArrayStringByEs6(filterByEs6, 3, "dao"));
