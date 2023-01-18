CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

-- Create a table to store data

CREATE TABLE
    syrups(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(20) NOT NULL COMMENT 'the name of the product',
        viscosity INT NOT NULL DEFAULT 5,
        color VARCHAR(15),
        flavor VARCHAR(20) NOT NULL DEFAULT 'Maple',
        canadian BOOLEAN NOT NULL DEFAULT true
    ) default charset utf8 COMMENT '';

-- Delete a table in it's entirity

DROP TABLE syrups;

-- Insert to add data to table (CREATE)

INSERT into
    syrups (
        name,
        viscosity,
        color,
        flavor,
        canadian
    )
VALUES (
        "Grandma Sycamore's",
        7,
        'brown',
        'Maple',
        false
    );

INSERT into
    syrups (
        name,
        viscosity,
        color,
        flavor,
        canadian
    )
VALUES (
        "Cough Max",
        2,
        'red',
        'Cherry',
        false
    );

("Grandma Sycamore's", 7, 'brown', 'Maple', false);

INSERT into
    syrups (
        name,
        viscosity,
        color,
        flavor,
        canadian
    )
VALUES (
        "Welches",
        1,
        'purple',
        'Huckleberry',
        false
    );

INSERT into
    syrups (
        name,
        viscosity,
        color,
        flavor,
        canadian
    )
VALUES (
        "High Fructose Corn",
        10,
        'light yellow',
        'Freedom',
        false
    );

INSERT into
    syrups (
        name,
        viscosity,
        color,
        flavor,
        canadian
    )
VALUES (
        "Pure Tree Sap",
        8,
        'light brown',
        'Maple and bark',
        true
    );

-- SELECT to Get data from a table

SELECT * FROM syrups;

-- You specific Column selects

SELECT id, id, name AS syrup_name, viscosity from syrups;

-- WHERE truncates the results by it's CONDITION

-- ORDER BY sorts the table by that field

SELECT * FROM syrups WHERE viscosity < 8 ORDER BY viscosity;

-- SECTION CARS

CREATE TABLE
    cars(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        make VARCHAR(255) NOT NULL,
        model VARCHAR(255) NOT NULL,
        year INT NOT NULL,
        price DOUBLE NOT NULL,
        description TEXT,
        color VARCHAR(10),
        imgUrl VARCHAR(255),
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update'
    ) default charset utf8mb4 COMMENT "for the emojis";

DROP TABLE cars;

INSERT INTO
    cars (
        make,
        model,
        year,
        price,
        color,
        `imgUrl`,
        description
    )
VALUES (
        'Toyota',
        'Bugati',
        2000,
        12.99,
        '#000000',
        'https://s1.cdn.autoevolution.com/images/news/bugatti-chiron-gets-toyota-camry-face-swap-design-still-works-139036_1.jpg',
        'A Sick black toyota bugati hotwheels'
    );

INSERT INTO
    cars (
        make,
        model,
        year,
        price,
        color,
        `imgUrl`,
        description
    )
VALUES (
        'Toyota',
        'Telsa',
        2000,
        1200.50,
        '#FFFFFF',
        'https://i.insider.com/617c5be123745d0018244b86?width=1136&format=jpeg',
        'A Sick competetor for the other one of a similar name, please do not sue us.'
    );

INSERT INTO
    cars (
        make,
        model,
        year,
        price,
        color,
        `imgUrl`,
        description
    )
VALUES (
        'Toyota',
        'Slingshot',
        2002,
        150.50,
        '#FFFFFF',
        'https://cdn1.polaris.com/globalassets/slingshot/2023/model/vehicle-cards/us/slingshot-slr-us-my23-a85a-red-shadow-m.png?v=ac0e4548&format=webp',
        'Everything rattles out of the box.'
    );

INSERT INTO
    cars (
        make,
        model,
        year,
        price,
        color,
        `imgUrl`,
        description
    )
VALUES (
        '🦧',
        'Oslo',
        2002,
        150.50,
        '#FFFFFF',
        'https://images.squarespace-cdn.com/content/v1/5a00ee59914e6b9803131e8f/f8c7ef16-ca18-4317-b30a-82a61e1bd8d9/Screen+Shot+2022-01-02+at+7.05.51+PM.png',
        'Everything rattles out of the box.'
    );

SELECT LAST_INSERT_ID();

-- PUT or update car

UPDATE cars
Set
    make = '🚤',
    model = 'speedboat',
    year = 2222,
    color = 'rock',
    description = "What i've been driving to school these days",
    imgUrl = "https://sportshub.cbsistatic.com/i/2021/03/17/9ec01251-4341-459a-9bc2-c222ea9f7418/spongebob-squarepants-boulder-1177707.jpg"
WHERE id = 7;

DELETE from cars WHERE id = 120;

-- Section Houses

CREATE TABLE
    houses(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        bedroom INT NOT NULL,
        bathroom INT NOT NULL,
        level INT NOT NULL,
        price DOUBLE NOT NULL,
        description TEXT NOT NULL,
        imgUrl VARCHAR(255),
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update'
    ) DEFAULT charset utf8mb4 COMMENT "for the emojis";

INSERT INTO
    houses (
        bedroom,
        bathroom,
        level,
        price,
        description,
        `imgUrl`
    )
VALUES (
        4,
        2,
        2,
        350000,
        'Cute cottage in the woods',
        'https://images.unsplash.com/photo-1529781833076-5f422f69d1af?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8OXx8Y290dGFnZSUyMGluJTIwd29vZHN8ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60'
    );

INSERT INTO
    houses (
        bedroom,
        bathroom,
        level,
        price,
        description,
        `imgUrl`
    )
VALUES (
        1,
        1,
        1,
        200000,
        'Gnome home',
        'https://images.unsplash.com/photo-1605644641464-80618f2d8ef6?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8Y290dGFnZSUyMGluJTIwd29vZHN8ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60'
    );

INSERT INTO
    houses (
        bedroom,
        bathroom,
        level,
        price,
        description,
        `imgUrl`
    )
VALUES (
        8,
        5,
        3,
        2000000,
        'Castle on the lake',
        'https://images.unsplash.com/photo-1651428106138-c723bbd7f1b0?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8bWFuc2lvbiUyMG9uJTIwbGFrZXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60'
    );

INSERT INTO
    houses (
        bedroom,
        bathroom,
        level,
        price,
        description,
        `imgUrl`
    )
VALUES (
        6,
        14,
        3,
        2800000,
        'Beautiful victorian home on acreage.',
        'https://images.unsplash.com/photo-1452626212852-811d58933cae?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8dWx0cmElMjBtb2Rlcm4lMjBob3VzZXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60'
    );

SELECT LAST_INSERT_ID();

UPDATE houses
Set
    bedroom = 2,
    bathroom = 1,
    level = 1,
    price = 50000,
    description = 'Gnome home, sweet home.',
    imgUrl = 'https://images.unsplash.com/photo-1605644641464-80618f2d8ef6?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8Y290dGFnZSUyMGluJTIwd29vZHN8ZW58MHx8MHx8&auto=format&fit=crop&w=500&q=60'
WHERE id = 2;

DELETE from houses WHERE id = 4;

-- SECTION Jobs

CREATE TABLE
    jobs(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        title VARCHAR(30) NOT NULL COMMENT 'job title',
        company VARCHAR(20) NOT NULL,
        description TEXT,
        salary INT NOT NULL,
        hours INT NOT NULL,
        remote BOOLEAN NOT NULL DEFAULT false,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update'
    ) default charset utf8mb4 COMMENT "for the emojis";

INSERT INTO
    jobs (
        title,
        company,
        description,
        salary,
        hours,
        remote
    )
VALUES (
        'Book Reviewer',
        'Barnes and Noble',
        'Read all the things, give all the opinions',
        100000,
        48,
        true
    );

UPDATE jobs
Set
    title = 'Book Reviewer',
    company = 'Barnes and Noble',
    description = 'Read all the things, give all the opinions.',
    salary = 50000,
    hours = 40,
    remote = true
WHERE id = 5;

DELETE from jobs WHERE id = 9;