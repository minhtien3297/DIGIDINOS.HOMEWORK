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

//khoi tao list filter
var filterListProduct = [];

/**
 * Sum quality
 * @param {number} total
 * @param {number} quality
 * @returns{number} total
 */
function getQuality(total, quality) {
  return total + quality;
}

/**
 * Get list total quality by reduce methods
 * @param {Array} listProduct
 * @returns{Array} List
 */
function totalProductReduce(listProduct) {
  listProduct.forEach((element) => {
    if (element.isDeleted) {
      filterListProduct.push(element.quality);
    }
  });

  return filterListProduct.reduce(getQuality, 0);
}

/**
 * Get list total quality
 * @param {Array} listProduct
 * @returns{Array} List
 */
function totalProduct(listProduct) {
  var totalQuality = 0;

  listProduct.forEach((element) => {
    if (element.isDeleted) {
      totalQuality += element.quality;
    }
  });

  return totalQuality;
}

//Kiem tra
console.log(totalProduct(listProduct));

console.log(totalProductReduce(listProduct));
