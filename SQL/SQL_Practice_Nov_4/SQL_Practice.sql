-- Practice 1
SELECT * FROM employees WHERE last_name = 'Zlotkey'
-- Option 1
SELECT * FROM employees  WHERE department_id = 80 AND last_name <> 'Zlotkey'
-- Subquery
SELECT * FROM employees  WHERE department_id = 
(SELECT department_id FROM employees WHERE last_name = 'Zlotkey') AND last_name <> 'Zlotkey'

-- Inner Join
SELECT * FROM employees e1
INNER JOIN employees e2 on e1.department_id = e2.department_id
WHERE e2.last_name = 'Zlotkey' AND e1.last_name <> 'Zlotkey'

SELECT * FROM departments
-- job_id linked to dbo.jobs

-- Practice 2
--- Calculate avg salary
SELECT employee_id, last_name, salary 
FROM employees
WHERE salary > (SELECT AVG(salary) FROM employees)
ORDER BY salary ASC

-- Practice 3
SELECT  employee_id, last_name FROM employees e
WHERE department_id IN 
		(SELECT department_id FROM employees WHERE last_name LIKE '%u%')
---- Join
SELECT distinct e.employee_id, e.last_name FROM employees e
JOIN employees d ON e.department_id = d.department_id
WHERE e.last_name = '%u%'

-- Practice 4
--- on: tren dieu kien nao
---- Sub-query
SELECT e.last_name, e.department_id, e.job_id 
FROM employees e JOIN departments d
ON e.department_id = d.department_id WHERE location_id = 1700



-- Practice 4 - Change reqs
SELECT e.last_name, e.department_id, e.job_id 
FROM employees e JOIN departments d on e.department_id = d.department_id
JOIN locations l ON l.location_id = d.location_id
WHERE city = 'Seattle'


-- left join example
SELECT employee_id, department_name FROM employees e
left join departments d on e.department_id = d.department_id
-- hien thi tat ca employees co department = finance va location_id = 1700
SELECT employee_id FROM employees e
JOIN departments d on e.department_id = d.department_id where department_name = 'Finance'
UNION ALL 
SELECT employee_id FROM employees e
JOIN departments d on e.department_id = d.department_id where location_id = 1700

-- Practice 5
--- Sub-query
SELECT last_name, salary FROM employees
WHERE manager_id in 
(SELECT employee_id FROM employees WHERE last_name = 'King')

--- Join
SELECT e1.last_name, e1.salary FROM employees e1
JOIN employees e2 ON e1.manager_id = e2.employee_id
WHERE e2.last_name = 'King'

-- Practice 6
--- Join
SELECT e.department_id,e.last_name, e.job_id 
FROM employees e JOIN departments d
ON e.department_id = d.department_id 
WHERE department_name = 'Executive'

--- Sub-query
SELECT department_id, last_name, job_id
FROM employees
WHERE department_id IN (SELECT department_id
			FROM departments
			WHERE department_name = 'Executive')


-- Practice 7

--- Sub-query
SELECT employee_id, last_name, salary
FROM employees
WHERE department_id IN (SELECT department_id
			FROM employees
			WHERE last_name LIKE '%u%' AND last_name NOT LIKE '%u%u%')
AND salary > (SELECT AVG(salary)FROM employees);

--- Union
SELECT employee_id, last_name, salary
FROM employees
WHERE department_id IN (SELECT department_id
			FROM employees
			WHERE last_name LIKE '%u%' AND last_name NOT LIKE '%u%u%')
UNION
SELECT employee_id, last_name, salary
FROM employees
WHERE salary > (SELECT AVG(salary) FROM employees)


-- Practice 8
SELECT ROUND(MAX(salary),0) "Maximum",
ROUND(MIN(salary),0) "Minimum",
ROUND(SUM(salary),0) "Sum",
ROUND(AVG(salary),0) "Average"
FROM employees

--- No decimal point version (db cannot save data in float)
SELECT 
CAST(MAX(salary) AS INT),
CAST(MIN(salary) AS INT),
CAST(SUM(salary) AS INT),
CAST(AVG(salary) AS INT)
FROM employees

-- Practice 9
SELECT last_name "Last name",
LEN(last_name) "Length of last name"
FROM employees
WHERE last_name LIKE 'J%'
OR last_name LIKE 'M%'
OR last_name LIKE 'A%'
ORDER BY last_name ;

--- Improved version
SELECT UPPER(LEFT(last_name,1)) + LOWER(RIGHT(last_name,len(last_name)-1)),LEN(last_name)
FROM employees
WHERE last_name LIKE 'J%'
OR last_name LIKE 'M%'
OR last_name LIKE 'A%'
ORDER BY last_name ;

--- Best version
SELECT UPPER(LEFT(last_name,1)) + LOWER(RIGHT(last_name,len(last_name)-1)),LEN(last_name)
FROM employees
WHERE UPPER(SUBSTRING(last_name,1,1)) IN ('J','A','M','L')
ORDER BY last_name



-- Practice 10
SELECT employee_id, last_name, salary, CAST(salary + (salary*15/100) AS NUMERIC(10,0)) "New salary" 
FROM employees;

-- Practice 11
SELECT last_name, department_id, CAST('null' AS varchar)
FROM employees
UNION
SELECT CAST('null' AS varchar), department_id, department_name
FROM departments
ORDER BY 1;

-- Practice 12
SELECT e.employee_id FROM employees e 
JOIN employees m ON e.manager_id = m.employee_id
WHERE e.hire_date > m.hire_date
UNION
SELECT e.employee_id FROM employees e 
JOIN departments d on e.department_id = d.department_id
JOIN locations l on d.location_id = l.location_id
WHERE city = 'Toronto'

-- MORE
SELECT * from employees
INSERT INTO employees(
SELECT first_name INTO employee_1