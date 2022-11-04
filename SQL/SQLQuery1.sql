SELECT e.employee_id, e.last_name, d.department_id, department_name
FROM employees e JOIN departments d
ON (e.department_id = d.department_id)
AND e.manager_id = 149;