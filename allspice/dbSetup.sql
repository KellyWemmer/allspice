CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

-- NOTE Create RECIPE
CREATE TABLE IF NOT EXISTS recipe (
  id INT AUTO_INCREMENT PRIMARY KEY,
  picture VARCHAR(255),
  title VARCHAR(255) NOT NULL,
  subtitle VARCHAR(255),
  category VARCHAR(255),
  creatorId VARCHAR(255) NOT NULL,

  FOREIGN KEY (creatorId) REFERENCES accounts(id),
)default charset utf8 COMMENT '';

INSERT INTO recipe
(picture, title, subtitle, category, creatorId)
VALUES
('https://images.unsplash.com/photo-1528736235302-52922df5c122?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1254&q=80', 'Grilled Cheese', "It's Cheesy!", 'Sandwiches', '6323975f1dfa4bbd3bd63c22');

-- NOTE CREATE INGREDIENT
CREATE TABLE IF NOT EXISTS ingredient (
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  quantity VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  
  FOREIGN KEY (recipeId) REFERENCES recipe(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

INSERT INTO ingredient 
(name, quantity, recipeId)
VALUES
("bread", "2 slices", 10);

-- NOTE Create STEP
CREATE TABLE IF NOT EXISTS step (
  id INT AUTO_INCREMENT PRIMARY KEY,
  position INT NOT NULL,
  body VARCHAR(255) NOT NULL,
  recipeID INT NOT NULL,

  FOREIGN KEY (recipeId) REFERENCES recipe(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

INSERT INTO step 
(position, body, recipeId)
VALUES
(1, "melt butter in pan on medium heat", 10);

-- NOTE create FAVORITE
CREATE TABLE IF NOT EXISTS favorite (
  id INT AUTO_INCREMENT PRIMARY KEY,
  accountId VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,

  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeId) REFERENCES recipe(id) ON DELETE CASCADE
)default charset utf8 COMMENT '';

INSERT INTO favorite 
(accountId, recipeId)
VALUES
('6323975f1dfa4bbd3bd63c22', 7)








