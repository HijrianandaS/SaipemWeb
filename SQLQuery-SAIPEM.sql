use tes

-- Membuat tabel company_1
CREATE TABLE company_1 (
  company_code_1 VARCHAR(5) PRIMARY KEY,
  company_name VARCHAR(30)
);

-- Membuat tabel company_2
CREATE TABLE company_2 (
  company_code_2 VARCHAR(5) PRIMARY KEY,
  company_code_1 VARCHAR(5),
  company_name VARCHAR(30),
  FOREIGN KEY (company_code_1) REFERENCES company_1(company_code_1)
);

-- Insert data ke tabel company_1
INSERT INTO company_1 (company_code_1, company_name)
VALUES ('SP', 'SAIPEM'), ('JV', 'CCS JV');

-- Insert data ke tabel company_2
INSERT INTO company_2 (company_code_2, company_code_1, company_name)
VALUES ('SPA', 'SP', 'SAIPEM MILAN'), ('PTSI', 'SP', 'SAIPEM INDONESIA'), ('JVA', 'JV', 'CCS JV ASIA'), ('JVM', 'JV', 'CCS JV MILAN');

-- Membuat view untuk menampilkan data company_1 & company_2
GO
CREATE VIEW company_view AS
SELECT c1.company_code_1 AS company_code_1_1, c1.company_name AS company_name_1, c2.company_code_2, c2.company_name AS company_name_2
FROM company_1 c1
JOIN company_2 c2 ON c1.company_code_1 = c2.company_code_1;


-- Menampilkan data dari view company_view berdasarkan data yang diminta pada No 4
GO
SELECT * FROM company_view
WHERE company_name_2 LIKE 'SAIPEM%'
ORDER BY company_name_2 DESC;
