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
product = new Product();
product.id = 1;
product.name = "tien";
product.categoryId = 1;
product.saleDate = new Date(2014, 0, 1, 0, 0, 0, 0);
product.quality = 20;
product.isDeleted = true;

//Kiem tra
console.log(
  "product id is:" +
    product.id +
    " name is:" +
    product.name +
    " categoryId is:" +
    product.categoryId +
    " saleDate is:" +
    product.saleDate +
    " quality is:" +
    product.quality +
    " isDeleted is" +
    product.isDeleted
);
