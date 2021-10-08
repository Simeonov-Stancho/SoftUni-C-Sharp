function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   let inputs = document.querySelector('#inputs textarea');
   let bestRestorantOutput = document.querySelector('#bestRestaurant p');
   let workersOutput = document.querySelector('#workers p');

   function onClick() {
      let inputArray = JSON.parse(inputs.value);
      let restorants = {};

      inputArray.forEach(element => {
         let restorantInfo = element.split(' - ');
         let restorantName = restorantInfo[0];
         let restorantWorkers = restorantInfo[1].split(', ');
         let workers = [];

         for (let i = 0; i < restorantWorkers.length; i++) {
            let worker = {
               name: restorantWorkers[i].split(' ')[0],
               salary: Number(restorantWorkers[i].split(' ')[1]),
            }

            workers.push(worker);
         }

         if (restorants[restorantName]) {
            workers = workers.concat(restorants[restorantName].workers);
         }

         workers.sort((a, b) => b.salary - a.salary);
         let bestSalary = workers[0].salary;
         let averageSalary = workers.reduce((acc, x) => acc + x.salary, 0) / workers.length;

         restorants[restorantName] = {
            workers,
            bestSalary,
            averageSalary
         };
      });

      let bestRestorantAverageSalary = 0;
      let bestRestorant = undefined;

      for (const name in restorants) {
         if (restorants[name].averageSalary > bestRestorantAverageSalary) {
            bestRestorant = {
               name: name,
               workers: restorants[name].workers,
               bestSalary: restorants[name].bestSalary,
               averageSalary: restorants[name].averageSalary
            }

            bestRestorantAverageSalary = restorants[name].averageSalary;
         }
      }

      bestRestorantOutput.textContent = `Name: ${bestRestorant.name} Average Salary: ${bestRestorant.averageSalary.toFixed(2)} Best Salary: ${bestRestorant.bestSalary.toFixed(2)}`;
      let workersArray = [];
      bestRestorant.workers.forEach(x => {
         workersArray.push(`Name: ${x.name} With Salary: ${x.salary}`);
      });

      workersOutput.textContent = workersArray.join(' ');
   }
}