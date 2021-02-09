create table addressTable(
address_id int identity(1,1) primary key NOT NULL,
address_city varchar (40) NOT NULL,
address_street varchar (40) NOT NULL,
address_home_no int NOT NULL,
address_flat_no int,
);

create table worker(
worker_id int identity(1,1) primary key NOT NULL,
worker_pesel nchar(11) unique NOT NULL,
worker_name varchar (15) NOT NULL,
worker_surename varchar (30) NOT NULL,
);

create table delivery_type(
delivery_type_id int identity(1,1) primary key NOT NULL,
delivery_type varchar(20) NOT NULL,
delivery_cost money NOT NULL,
);

create table customer(
customer_id int identity(1,1) primary key NOT NULL,
customer_name varchar (30) NOT NULL,
customer_surename varchar (30),
customer_address_id int foreign key references addressTable(address_id) NOT NULL,
customer_phone int NOT NULL,
customer_email varchar (25) null,
customer_nip nchar(9) null
);

create table product(
product_id int identity(1,1) primary  key NOT NULL,
product_manufacturer_name varchar(40) NOT NULL,
product_name varchar (40) NOT NULL,
product_category_name varchar (20),
product_price money NOT NULL,
product_cost money NOT NULL
);

create table orderTable(
order_id int identity(1,1) primary key,
order_product_id int foreign key references product(product_id) NOT NULL,
order_delivery_type_id int foreign key references delivery_type(delivery_type_id) NOT NULL,
order_customer_id int foreign key references customer(customer_id) NOT NULL,
order_worker_id int foreign key references worker(worker_id) NOT NULL,
order_date datetime NOT NULL
);