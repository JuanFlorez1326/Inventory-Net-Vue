CREATE DATABASE Inventory;
USE Inventory;

CREATE TABLE Users(
document_id INT NOT NULL IDENTITY PRIMARY KEY,
name CHAR(30) NOT NULL,
lastname CHAR(30) NOT NULL,
email CHAR(100) UNIQUE NOT NULL,
password CHAR(100) NOT NULL,
phone CHAR(15) NOT NULL,
age CHAR(3)
);

CREATE TABLE Products(
id_product INT NOT NULL IDENTITY PRIMARY KEY,
user_product INT,
name_product CHAR(50) NOT NULL,
description VARCHAR(500),
tickets INT NOT NULL,
departures INT NOT NULL,
total INT NOT NULL,
seller CHAR(60),
FOREIGN KEY (user_product) REFERENCES Users(document_id)
);

CREATE TABLE Invoice(
id_invoice INT PRIMARY KEY IDENTITY NOT NULL,
id_product INT NOT NULL,
id_user INT NOT NULL,
FOREIGN KEY (id_product) REFERENCES Products(id_product),
FOREIGN KEY (id_user) REFERENCES Users(document_id)
);
