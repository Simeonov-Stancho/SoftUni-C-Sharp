function solve(data, criteria) {
    let employees = JSON.parse(data);
    let [currentCriteria, value] = criteria.split('-');

    return employees
        .filter(employee => (employee[currentCriteria] == value))
        .map((employee, i) => `${i}. ${employee.first_name} ${employee.last_name} - ${employee.email}`)
        .join('\n');
}


function solve1(data, criteria) {
    const employees = JSON.parse(data);

    const criterias = criteria.split('-');
    const currentCriteria = criterias[0];
    const value = criterias[1];

    if (criteria == 'all') {
        printEmployees(employees);
        return;
    } else {
        const filteredEmployees = employees.filter(e => e[currentCriteria] == value);
        printEmployees(filteredEmployees);
    }

    function printEmployees(employees) {
        let count = 0;
        employees.forEach(element => {
            console.log(`${count}. ${element.first_name} ${element.last_name} - ${element.email}`)
            count++;
        });
    }
}

solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`,
    'all'
);


solve(`[{
    "id": "1",
    "first_name": "Kaylee",
    "last_name": "Johnson",
    "email": "k0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Johnson",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  }, {
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }, {
    "id": "4",
    "first_name": "Evanne",
    "last_name": "Johnson",
    "email": "ev2@hostgator.com",
    "gender": "Male"
  }]`,
    'last_name-Johnson'
);