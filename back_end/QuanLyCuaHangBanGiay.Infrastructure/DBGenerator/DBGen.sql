DELETE FROM Brand;
INSERT INTO Brand (Id, Code, Name, CreatedDate, LastModifiedDate)
VALUES
    ('38b0c7b6-7a5e-442b-b9ec-79f9e9bdeed1', 'BR01', 'Adidas', '2023-03-01', '2023-03-01'),
    ('45e876c8-953f-4a6a-ae7c-8d35294e1a17', 'BR02', 'Nike', '2023-03-02', '2023-03-02'),
    ('6a2f8a4e-1e85-4db9-9dbb-9a877c4fb0a3', 'BR03', 'Bitis', '2023-03-03', '2023-03-03'),
    ('7e895bd6-124e-41b3-9a72-39f9817a0470', 'BR04', 'Converse', '2023-03-04', '2023-03-04'),
    ('9c59d9a1-2c3a-4c1b-8c1c-32f4b29a7cc9', 'BR05', 'Vans', '2023-03-05', '2023-03-05');

DELETE FROM Category;
INSERT INTO Category (Id, Code, Name, CreatedDate, LastModifiedDate)
VALUES
    ('db7e3b87-3e0a-4cf0-8a05-71d5ef18b8ad', 'CA01', N'Giày thể thao', '2023-03-01', '2023-03-01'),
    ('f527e009-156f-44e0-8542-df2b109d3a05', 'CA02', N'Giày chạy bộ', '2023-03-02', '2023-03-02'),
    ('a6d8c39d-d3c7-42f5-a946-4c94652b9c33', 'CA03', N'Giày bóng rổ', '2023-03-03', '2023-03-03'),
    ('dfc86268-87d2-4fcb-8e6f-2b87030e6714', 'CA04', N'Giày leo núi', '2023-03-04', '2023-03-04'),
    ('c0f7a6ae-936c-490a-a769-9e14a9e5a12d', 'CA05', N'Giày công sở', '2023-03-05', '2023-03-05');

DELETE FROM Color;
INSERT INTO Color (Id, Code, Name, CreatedDate, LastModifiedDate)
VALUES
    ('d7e26a5f-8e90-4d32-8be1-82f190a0a926', 'CO01', N'Trắng', '2023-03-01', '2023-03-01'),
    ('4fd0f8b7-3e33-4b89-a3ce-6b86a2448bf1', 'CO02', N'Đen', '2023-03-02', '2023-03-02'),
    ('e0c1a3a4-452c-432e-99c3-f25d24b2eac1', 'CO03', N'Xám', '2023-03-03', '2023-03-03'),
    ('75b88a6d-1e19-475f-9bc9-624eaad55a22', 'CO04', N'Xanh dương', '2023-03-04', '2023-03-04'),
    ('ab7637d2-7822-41ec-b8d3-9a3b60d5c9a3', 'CO05', N'Đỏ', '2023-03-05', '2023-03-05');

DELETE FROM Customers;
INSERT INTO Customers (Id, Code, FullName, PhoneNumber, Email, Address, Rank, CreatedDate, LastModifiedDate)
VALUES
    ('e4d8e05b-22e6-4c65-953e-68d6d4d784e1', 'CU01', N'Nguyễn Văn A', '0123456789', 'anguyen@email.com', N'Hà Nội', 1, '2023-03-01', '2023-03-01'),
    ('98f1e178-6a6c-491f-9233-2ea67a2e1d33', 'CU02', N'Trần Thị B', '0987654321', 'btran@email.com', N'TP HCM', 2, '2023-03-02', '2023-03-02'),
    ('b9e9ab02-20e2-43c9-bf41-ee5c937e7436', 'CU03', N'Lê Văn C', '0246813579', 'cle@email.com', N'Đà Nẵng', 3, '2023-03-03', '2023-03-03'),
    ('6d30b5c7-cf6e-4924-9ef9-271dcb36d330', 'CU04', N'Phạm Thị D', '135792468', 'dpham@email.com', N'Cần Thơ', 1, '2023-03-04', '2023-03-04'),
    ('f8495e9f-3f8f-447f-9a02-5e3ee8a3a4de', 'CU05', N'Hoàng Văn E', '1597531864', 'ehoang@email.com', N'Hải Phòng', 2, '2023-03-05', '2023-03-05');

DELETE FROM Employers;
INSERT INTO Employers (Id, Code, FullName, Gender, DateOfBirth, Address, PhoneNumber, Email, Role, Password, CreatedDate, LastModifiedDate)
VALUES
    ('a3b72f81-c1ab-45f2-bb9e-5b2b57779d3d', 'EM01', N'Nguyễn Thị X', 0, '2000-01-01', N'123 Đường A', '0123123123', 'xnguyen@email.com', 0, '123123', '2023-03-01', '2023-03-01'),
    ('f6ce66eb-1361-4cc7-a82a-5a9e0b42ec76', 'EM02', N'Lê Văn Y', 1, '1995-03-15', N'456 Đường B', '0246246246', 'yle@email.com', 1, '321321', '2023-03-02', '2023-03-02'),
    ('bfa3b25a-79c0-4c3d-8e85-ec3d82dd1b06', 'EM03', N'Trần Thị Z', 0, '1998-11-30', N'789 Đường C', '0364827219', 'ztran@email.com', 0, '345345', '2023-03-03', '2023-03-03'),
    ('5b14e6ae-5f8a-48ea-9e09-212041f6e786', 'EM04', N'Phạm Văn D', 1, '1992-09-07', N'159 Đường D', '0495049504', 'dpham@email.com', 1, '9999999', '2023-03-04', '2023-03-04'),
    ('1d52a43c-0b6f-431e-b5e7-3ef2991cbb22', 'EM05', N'Hoàng Thị E', 0, '1989-02-14', N'357 Đường E', '0586756575', 'ehoang@email.com', 0, '25252525', '2023-03-05', '2023-03-05');

DELETE FROM Images;
INSERT INTO Images (Id, Name, Path, CreatedDate, LastModifiedDate)
VALUES
    ('c0e5a98a-bac9-4a84-8ad2-3b76be23c432', 'image_1.jpg', 'https://res.cloudinary.com/dk2ygqizi/image_shoe_store/cimfcdtqkyeddky4tpz7', '2023-03-01', '2023-03-01'),
    ('7fd47958-d7e3-43e5-8f98-5721f8b6d69d', 'image_2.jpg', 'https://res.cloudinary.com/dk2ygqizi/image_shoe_store/ecvmufctykv8nzy6qvlh', '2023-03-02', '2023-03-02'),
    ('a1a71f56-665d-4525-88d5-3185b4282cc0', 'image_3.jpg', 'https://res.cloudinary.com/dk2ygqizi/image_shoe_store/qfkbjntgvvbyewz4kgs1', '2023-03-03', '2023-03-03'),
    ('e7fffd35-9b53-41eb-8f84-8a0e15ea168a', 'image_4.jpg', 'https://res.cloudinary.com/dk2ygqizi/image_shoe_store/lh9tzb4ndnq9g5zrqnkf', '2023-03-04', '2023-03-04'),
    ('da909a28-1a44-4f90-9741-9f1e05ef4e3f', 'image_5.jpg', 'https://res.cloudinary.com/dk2ygqizi/image_shoe_store/v0tmta8zdsimhelzvd9x', '2023-03-05', '2023-03-05');

DELETE FROM Material;
INSERT INTO Material (Id, Code, Name, CreatedDate, LastModifiedDate)
VALUES
    ('cd3cf6ab-fd95-4c49-a135-6e6ea8c11e02', 'MA01', N'Da tổng hợp', '2023-03-01', '2023-03-01'),
    ('9e847f44-eb8b-4e05-98a6-122bba7c4c6a', 'MA02', N'Da thật', '2023-03-02', '2023-03-02'),
    ('2c3a3e10-3c36-4b1a-b0b3-cc1c04a189b2', 'MA03', N'Vải canvas', '2023-03-03', '2023-03-03'),
    ('f07e4cdd-6da1-478b-9f9c-80e2c6d33df0', 'MA04', N'Vải dù', '2023-03-04', '2023-03-04'),
    ('b7b34491-62dd-4ff9-a8a9-805b96db5c74', 'MA05', N'Da lộn mặt', '2023-03-05', '2023-03-05');

DELETE FROM [Order];
INSERT INTO [Order] (Id, IdCustomer, IdEmployer, Code, CustomerPayment, BankTransfer, ChangeAmount, TotalAmount, CreatedDate, LastModifiedDate)
VALUES
    ('3dc21e4e-5b80-4e2d-bcfb-2b3d26f4fe9e', 'e4d8e05b-22e6-4c65-953e-68d6d4d784e1', 'a3b72f81-c1ab-45f2-bb9e-5b2b57779d3d', 'OR01', 1000000, 2000000, 500000, 2500000, '2023-03-01', '2023-03-01'),
    ('d1afed84-9c18-4e3f-81e3-aa870a14de07', 'e4d8e05b-22e6-4c65-953e-68d6d4d784e1', 'f6ce66eb-1361-4cc7-a82a-5a9e0b42ec76', 'OR02', 1500000, 1500000, 0, 3000000, '2023-03-02', '2023-03-02'),
    ('e7b7e8a3-6e06-48d6-9324-712d35ac9a9c', '98f1e178-6a6c-491f-9233-2ea67a2e1d33', 'bfa3b25a-79c0-4c3d-8e85-ec3d82dd1b06', 'OR03', 2000000, 3000000, 1000000, 5000000, '2023-03-03', '2023-03-03'),
    ('f4a15b5c-8562-45c2-8b6f-719b9177dd28', '6d30b5c7-cf6e-4924-9ef9-271dcb36d330', '1d52a43c-0b6f-431e-b5e7-3ef2991cbb22', 'OR04', 500000, 1500000, 600000, 2500000, '2023-03-04', '2023-03-04'),
    ('ac0579f7-9092-4a97-9d6f-9f9f44e138f1', 'f8495e9f-3f8f-447f-9a02-5e3ee8a3a4de', 'a3b72f81-c1ab-45f2-bb9e-5b2b57779d3d', 'OR05', 1000000, 2100000, 900000, 3000000, '2023-03-05', '2023-03-05');

DELETE FROM OrderDetails;
INSERT INTO OrderDetails (Id, IdOrder, IdProductDetail, NameProduct, Sale, Price, CreatedDate, LastModifiedDate)
VALUES
    ('cd3cf6ab-fd95-4c49-a135-6e6ea8c11e02', '3dc21e4e-5b80-4e2d-bcfb-2b3d26f4fe9e', 'e76c805a-f4de-4a7a-a8c9-9433f7f18f8a', N'Giày Adidas Superstar', 10, 500000, '2023-03-01', '2023-03-01'),
    ('9e847f44-eb8b-4e05-98a6-122bba7c4c6a', '3dc21e4e-5b80-4e2d-bcfb-2b3d26f4fe9e', 'e76c805a-f4de-4a7a-a8c9-9433f7f18f8a', N'Giày Vans Old Skool', 0, 800000, '2023-03-02', '2023-03-02'),
    ('2c3a3e10-3c36-4b1a-b0b3-cc1c04a189b2', 'e7b7e8a3-6e06-48d6-9324-712d35ac9a9c', 'fc575201-67af-4b71-8f4b-2187a5c38f2c', N'Giày Nike Air Max 90', 5, 1200000, '2023-03-03', '2023-03-03'),
    ('f07e4cdd-6da1-478b-9f9c-80e2c6d33df0', 'e7b7e8a3-6e06-48d6-9324-712d35ac9a9c', 'fc575201-67af-4b71-8f4b-2187a5c38f2c', N'Giày Bitis Hunter X', 0, 2000000, '2023-03-04', '2023-03-04'),
    ('b7b34491-62dd-4ff9-a8a9-805b96db5c74', 'ac0579f7-9092-4a97-9d6f-9f9f44e138f1', '3c08acdd-49ea-43e3-9f0d-3d5e2910f53d', N'Giày Converse 1970', 0, 1000000, '2023-03-05', '2023-03-05');

DELETE FROM Product;
INSERT INTO Product (Id, Code, Name, Description, CreatedDate, LastModifiedDate)
VALUES
    ('cd3cf6ab-fd95-4c49-a135-6e6ea8c11e02', 'PD01', N'Giày Adidas Superstar', N'Giày thể thao 3 sọc Adidas', '2023-03-01', '2023-03-01'),
    ('9e847f44-eb8b-4e05-98a6-122bba7c4c6a', 'PD02', N'Giày Nike Air Max 90', N'Giày chạy bộ đệm khí Nike', '2023-03-02', '2023-03-02'),
    ('2c3a3e10-3c36-4b1a-b0b3-cc1c04a189b2', 'PD03', N'Giày Bitis Hunter X', N'Giày leo núi cổ điển Bitis', '2023-03-03', '2023-03-03'),
    ('f07e4cdd-6da1-478b-9f9c-80e2c6d33df0', 'PD04', N'Giày Converse 1970', N'Giày Converse trắng cổ thấp', '2023-03-04', '2023-03-04'),
    ('b7b34491-62dd-4ff9-a8a9-805b96db5c74', 'PD05', N'Giày Vans Old Skool', N'Giày Vans kẻ caro cổ thấp', '2023-03-05', '2023-03-05');

DELETE FROM ProductDetail;
INSERT INTO ProductDetail (Id, IdProduct, IdBrand, IdCategory, IdColor, IdImage, IdMaterial, IdSize, Price, Quantity, CreatedDate, LastModifiedDate)
VALUES
    ('e76c805a-f4de-4a7a-a8c9-9433f7f18f8a', 'cd3cf6ab-fd95-4c49-a135-6e6ea8c11e02', '38b0c7b6-7a5e-442b-b9ec-79f9e9bdeed1', 'db7e3b87-3e0a-4cf0-8a05-71d5ef18b8ad', 'd7e26a5f-8e90-4d32-8be1-82f190a0a926', 'c0e5a98a-bac9-4a84-8ad2-3b76be23c432', 'cd3cf6ab-fd95-4c49-a135-6e6ea8c11e02', 'eb4c651d-9b12-41e5-9a02-d2652a2f49e9', 500000, 10, '2023-03-01', '2023-03-01'),
    ('d9fb48c5-906b-4b82-bc62-1e5ea315d66e', '9e847f44-eb8b-4e05-98a6-122bba7c4c6a', '38b0c7b6-7a5e-442b-b9ec-79f9e9bdeed1', 'db7e3b87-3e0a-4cf0-8a05-71d5ef18b8ad', '4fd0f8b7-3e33-4b89-a3ce-6b86a2448bf1', '7fd47958-d7e3-43e5-8f98-5721f8b6d69d', 'cd3cf6ab-fd95-4c49-a135-6e6ea8c11e02', 'eb4c651d-9b12-41e5-9a02-d2652a2f49e9', 1200000, 8, '2023-03-02', '2023-03-02'),
    ('fc575201-67af-4b71-8f4b-2187a5c38f2c', '2c3a3e10-3c36-4b1a-b0b3-cc1c04a189b2', '45e876c8-953f-4a6a-ae7c-8d35294e1a17', 'f527e009-156f-44e0-8542-df2b109d3a05', 'e0c1a3a4-452c-432e-99c3-f25d24b2eac1', 'a1a71f56-665d-4525-88d5-3185b4282cc0', '2c3a3e10-3c36-4b1a-b0b3-cc1c04a189b2', '3f65d226-7e8c-48ec-85d0-0a06c6f0a2f9', 2000000, 5, '2023-03-03', '2023-03-03'),
    ('3c08acdd-49ea-43e3-9f0d-3d5e2910f53d', 'f07e4cdd-6da1-478b-9f9c-80e2c6d33df0', '7e895bd6-124e-41b3-9a72-39f9817a0470', 'dfc86268-87d2-4fcb-8e6f-2b87030e6714', '75b88a6d-1e19-475f-9bc9-624eaad55a22', 'e7fffd35-9b53-41eb-8f84-8a0e15ea168a', 'f07e4cdd-6da1-478b-9f9c-80e2c6d33df0', 'c8af5761-4c4f-4371-87d7-fcafedcc7a48', 1000000, 15, '2023-03-04', '2023-03-04'),
    ('8fd051f1-8524-47a2-9361-cf08e1c3f596', 'b7b34491-62dd-4ff9-a8a9-805b96db5c74', '9c59d9a1-2c3a-4c1b-8c1c-32f4b29a7cc9', 'c0f7a6ae-936c-490a-a769-9e14a9e5a12d', 'ab7637d2-7822-41ec-b8d3-9a3b60d5c9a3', 'da909a28-1a44-4f90-9741-9f1e05ef4e3f', 'b7b34491-62dd-4ff9-a8a9-805b96db5c74', 'a53257a1-4d9b-4962-a36a-c21bc3d1d5fc', 800000, 20, '2023-03-05', '2023-03-05');

DELETE FROM SaleDetail;
INSERT INTO SaleDetail (Id, IdSale, IdProductDetail, Price, ChangeAmount, CreatedDate, LastModifiedDate)
VALUES
    ('e1b7a8cd-82e3-4b9c-b3c1-195e2de0653a', 'd5edc47c-674c-4d7a-9e8b-50aaf9c8b9d1', 'e76c805a-f4de-4a7a-a8c9-9433f7f18f8a', 450000, 50000, '2023-03-01', '2023-03-01'),
    ('d28b9e3f-4e91-41c9-9b69-8b36fba8b2b6', 'd5edc47c-674c-4d7a-9e8b-50aaf9c8b9d1', 'd9fb48c5-906b-4b82-bc62-1e5ea315d66e', 720000, 80000, '2023-03-02', '2023-03-02');

DELETE FROM Sales;
INSERT INTO Sales (Id, Code, Name, SaleType, Value, StartDate, EndDate, Status, CreatedDate, LastModifiedDate)
VALUES
    ('d5edc47c-674c-4d7a-9e8b-50aaf9c8b9d1', 'SA01', N'Giảm giá mùa hè', 0, 10, '2023-05-01', '2023-08-01', 1, '2023-03-01', '2023-03-01'),
    ('f8c3c5e2-273b-468e-980e-9e8e17563c01', 'SA02', N'Flash sale tháng 5', 1, 20, '2023-05-10', '2023-05-15', 1, '2023-03-02', '2023-03-02'),
    ('c8746a6d-3b03-4a0e-8e13-1522349e0b9b', 'SA03', N'Giảm sốc cuối năm', 0, 30, '2023-11-20', '2023-12-31', 0, '2023-03-03', '2023-03-03'),
    ('edc7c9a3-82b5-4f3e-8b5e-5379c3b01d9d', 'SA04', N'Tri ân khách hàng', 0, 15, '2023-03-08', '2023-03-31', 1, '2023-03-04', '2023-03-04'),
    ('6f96860c-365f-46e5-92a3-5a834c768c4b', 'SA05', N'Mừng khai trương', 1, 50, '2023-10-01', '2023-10-03', 0, '2023-03-05', '2023-03-05');

DELETE FROM Size;
INSERT INTO Size (Id, Code, Name, CreatedDate, LastModifiedDate)
VALUES
    ('eb4c651d-9b12-41e5-9a02-d2652a2f49e9', 'SZ01', '35', '2023-03-01', '2023-03-01'),
    ('3f65d226-7e8c-48ec-85d0-0a06c6f0a2f9', 'SZ02', '36', '2023-03-02', '2023-03-02'),
    ('c8af5761-4c4f-4371-87d7-fcafedcc7a48', 'SZ03', '37', '2023-03-03', '2023-03-03'),
    ('710f42b2-10e9-4be2-8460-4f5c529131d9', 'SZ04', '38', '2023-03-04', '2023-03-04'),
    ('a53257a1-4d9b-4962-a36a-c21bc3d1d5fc', 'SZ05', '39', '2023-03-05', '2023-03-05');
