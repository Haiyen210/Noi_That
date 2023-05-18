
// Create a new database.
use("DB_NoiThat");

// Create a new collection.
db.createCollection("Category");
db.Category.insertMany([
    {_id : ObjectId("61a6058e6c43f32854e51f51"),Code:"C001",CategoryName:"Sofa",Status:1},
    {_id : ObjectId("61a6058e6c43f32854e51f52"),Code:"C002",CategoryName:"Giường",Status:1},
    {_id : ObjectId("61a6058e6c43f32854e51f53"),Code:"C003",CategoryName:"Cửa lá sách",Status:1},
    {_id : ObjectId("61a6058e6c43f32854e51f54"),Code:"C004",CategoryName:"Tủ quần áo",Status:1},
    {_id : ObjectId("61a6058e6c43f32854e51f55"),Code:"C005",CategoryName:"Tủ tivi - Tủ giày",Status:1},
    {_id : ObjectId("61a6058e6c43f32854e51f56"),Code:"C006",CategoryName:"Đồ Decor",Status:1},
    {_id : ObjectId("61a6058e6c43f32854e51f57"),Code:"C007",CategoryName:"Bàn",Status:1},
    {_id : ObjectId("61a6058e6c43f32854e51f58"),Code:"C008",CategoryName:"Ghế",Status:1},
    {_id : ObjectId("61a6058e6c43f32854e51f59"),Code:"C009",CategoryName:"Combo",Status:1},
]);

db.createCollection("Product");
db.Product.insertMany([
    {_id:ObjectId("71a6058e6c43f32854e51f51"),Code:"S01",ProductName:"Ghế Sofa Eave Modular SD-S021",CategoryId:ObjectId("61a6058e6c43f32854e51f51"),Price:300000,SalePrice:239000,Image:"/Images/sofa1.jpg",Description:"Màu Sắc : Hồng, xám, trắng, xanh,Chất Liệu : Vải nhập khẩu Singapore ( vải nhập Bỉ vui lòng liên hệ )Kích Thước : 1800 x 900 x 420 / 2200 x 900 x 420Smart Decor nhận sản xuất may đo các mẫu sản phẩm dựa theo kích thước, màu sắc, chất liệu riêng biệt dành cho không gian sống của riêng bạn. Vui lòng liên hệ ngay với chúng tôi để nhận báo giá và các chính sách ưu đãi.Ngoài ra, SmartDecor còn nhận thiết kế và phối cảnh 3D, 2D cho không gian căn hộ/nhà phố/ biệt thự.Liên hệ để được tư vấn miễn phí: 0911.933.938",Status:1},

]);
db.createCollection("Role");
db.Role.insertMany([
    {_id:ObjectId("81a6058e6c43f32854e51f51"),Code:"Admin",Name:"Quản trị"},
    {_id:ObjectId("81a6058e6c43f32854e51f52"),Code:"User",Name:"Người dùng"},]);


db.createCollection("Account");
db.Account.insertMany([
    {_id:ObjectId("81a6058e6c43f32854e51f87"),Fullname:"Nguyễn Văn A",Email:"anv@gmail.com",Phone:"0132549875",Password:"123456789",RoleId:ObjectId("81a6058e6c43f32854e51f51")},
    {_id:ObjectId("81a6058e6c43f32854e51f88"),Fullname:"Nguyễn Văn B",Email:"bnv@gmail.com",Phone:"0984549875",Password:"123456789",RoleId:ObjectId("81a6058e6c43f32854e51f52")}
]);

db.createCollection("Order");
db.createCollection("OrderDetail");

db.Category.find({})