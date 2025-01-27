--create database epislondb;

--use epislondb
create table products(
product_id int primary key not null identity(100,1),
product_name varchar(50) not null,
product_description varchar(max),
product_price decimal(18,2) default(0)
)

insert into products (product_name,product_description,product_price) values('dell xps 15','new 15 inch laptop from dell',120000.00)
insert into products (product_name,product_description,product_price) values('lenovo thinkpad 13','new 13 inch laptop from lenovo',110000.00)
insert into products (product_name,product_description,product_price) values('hp probook delta','new probook laptop from hp',130000.00)

select * from products

create procedure sp_GetProductById
@id int
as
begin
select product_id as ID, product_name as NAME,product_description as DESCRIPTION,product_price as PRICE from products where product_id=@id
end
