using EmployeeApp.UI.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.UI
{
    public class IO
    {
        // Fields
        private readonly Uri _uri;
        private static readonly HttpClient httpClient = new HttpClient();
        
        // Constructors
        public IO (Uri uri)
        {
            _uri = uri;
        }

        // Methods
        public async Task BeginAsync()
        {
            Console.WriteLine("ConsoleApp Running...");
            bool loop = true;

            do
            {
                int choice = MainMenu();
                switch(choice)
                {
                    case -1:
                        Console.WriteLine("Bad input. Please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case 0:
                        loop = false;
                        Console.WriteLine("Press any key to close the app.");
                        Console.ReadLine();
                        break;
                    case 1:
                        await DisplayAllEmployeesAsync();
                        break;
                    case 2:
                        await DisplayEmployeeAsync();
                        break;
                    case 3:
                        await AddEmployeeAsync();
                        break;
                    case 4:
                        await UpdateEmployeeAsync();
                        break;
                    case 5:
                        await DeleteEmployeeAsync();
                        break;
                    case 9:
                        await GetLocationsAsync();
                        break;
                }
            }while (loop);
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            Console.WriteLine("Please select the option of your choice:");
            Console.WriteLine("[1] - Get all employees information");
            Console.WriteLine("[2] - Get an employee information");
            Console.WriteLine("[3] - Add a new employee");
            Console.WriteLine("[4] - Update an existing employee");
            Console.WriteLine("[5] - Delete an employee");
            Console.WriteLine("[9] - Get all locations");
            Console.WriteLine("[0] - Exit");
            string? input = Console.ReadLine();
            Console.Clear();

            if(int.TryParse(input, out choice))
            {
                return choice;
            }
            else
            {
                return -1;
            }
        }

        // Display all employees in the database
        private async Task DisplayAllEmployeesAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri.ToString() + "api/employees");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if(response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var employees = await response.Content.ReadFromJsonAsync<List<EmployeeDTO>>();

                if(employees != null)
                {
                    Console.WriteLine("Employees: ");
                    foreach(var employee in employees)
                    {
                        Console.WriteLine("Employee Id: " + employee.Id);
                        Console.WriteLine("Name: " + employee.FirstName + " " + employee.LastName);
                        Console.WriteLine("Birthdate: " + employee.BirthDate);
                        Console.WriteLine("Department: " + employee.Department);
                        Console.WriteLine("Title: " + employee.Title);
                        Console.WriteLine("Hired Date: " + employee.HiredDate);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No employees found.");
                }
            }
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadLine();
            Console.Clear();
        }

        // Display an employee by Employee Id
        private async Task DisplayEmployeeAsync()
        {
            int employeeId = -1;
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine("Enter the Employee Id");
                    employeeId = int.Parse(Console.ReadLine());
                    loop = false;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid numerical value.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri.ToString() + $"api/employee?Id={employeeId}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var employee = await response.Content.ReadFromJsonAsync<List<EmployeeDTO>>();

                if(employee.Count == 0)
                { 
                    Console.WriteLine("No employee with Id: {0} found.", employeeId);
                }
                else
                {
                    Console.WriteLine("Employee Id: " + employee[0].Id);
                    Console.WriteLine("Name: " + employee[0].FirstName + " " + employee[0].LastName);
                    Console.WriteLine("Birthdate: " + employee[0].BirthDate);
                    Console.WriteLine("Department: " + employee[0].Department);
                    Console.WriteLine("Title: " + employee[0].Title);
                    Console.WriteLine("Hired Date: " + employee[0].HiredDate);
                }
            }
            Console.WriteLine("\nPress any key to go back to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        // Add a new employee into the database
        private async Task AddEmployeeAsync()
        {
            // variables for an Employee
            string firstName = "";
            string lastName = "";
            DateTime birthDate = DateTime.MinValue;
            int branchId = -1;
            string department = "";
            string title = "";

            Console.WriteLine("Adding a new employee\n");
            // Loop for first name
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Enter first name:");
                firstName = Console.ReadLine();
                if (string.IsNullOrEmpty(firstName))
                {
                    Console.WriteLine("Please enter a valid first name.\n");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
                else
                {
                    loop = false;
                }
            }
            // Loop for last name
            bool loop1 = true;
            while (loop1)
            {
                Console.WriteLine("Enter last name:");
                lastName = Console.ReadLine();
                if (string.IsNullOrEmpty(lastName))
                {
                    Console.WriteLine("Please enter a valid last name.\n");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
                else
                {
                    loop1 = false;
                }
            }
            // Loop for birthdate
            bool loop2 = true;
            while (loop2)
            {
                Console.WriteLine("Enter birthdate (yyyy-mm-dd):");
                string temp = Console.ReadLine();
                if (!DateTime.TryParse(temp, out birthDate))
                {
                    Console.WriteLine("Please enter a valid birthdate.\n");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
                else if (DateTime.Parse(temp) < birthDate)
                {
                    Console.WriteLine("Birthdate cannot be older {0}.", birthDate);
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
                else
                {
                    birthDate = DateTime.Parse(temp);
                    loop2 = false;
                }
            }
            // Loop for branch id
            bool loop3 = true;
            while (loop3)
            {
                Console.WriteLine("Enter branch id:");
                string temp = Console.ReadLine();
                if (!int.TryParse(temp, out branchId))
                {
                    Console.WriteLine("Please enter a valid branch id.\n");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
                else if (int.Parse(temp) == 0)
                {
                    Console.WriteLine("Branch Id cannot be 0.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
                else
                {
                    branchId = int.Parse(temp);
                    loop3 = false;
                }
            }
            // Loop for department
            bool loop4 = true;
            do
            {
                Console.WriteLine("Enter department name:");
                department = Console.ReadLine();
                if (string.IsNullOrEmpty(department))
                {
                    Console.WriteLine("Please enter a valid department name.\n");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
                else
                {
                    loop4 = false;
                }
            } while (loop4);
            // Loop for title
            bool loop5 = true;
            do
            {
                Console.WriteLine("Enter title:");
                title = Console.ReadLine();
                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Please enter a valid title.\n");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
                else
                {
                    loop5 = false;
                }
            } while (loop5);
            //Get current time
            DateTime hiredDate = DateTime.Now;

            // Create a new employee
            EmployeeDTO newEmp = new EmployeeDTO();
            newEmp.FirstName = firstName;
            newEmp.LastName = lastName;
            newEmp.BirthDate = birthDate;
            newEmp.BranchId = branchId;
            newEmp.Department = department;
            newEmp.Title = title;
            newEmp.HiredDate = hiredDate;

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(_uri.ToString() + "api/addEmp", newEmp);

            response.EnsureSuccessStatusCode();     

            var employee = await response.Content.ReadFromJsonAsync<List<EmployeeDTO>>();

            if (employee.Count == 0)
            {
                Console.WriteLine("\nNo employee added.");
            }
            else
            {
                Console.WriteLine("\nEmployee added:");
                Console.WriteLine("Employee Id: " + employee[0].Id);
                Console.WriteLine("Name: " + employee[0].FirstName + " " + employee[0].LastName);
                Console.WriteLine("Birthdate: " + employee[0].BirthDate);
                Console.WriteLine("Department: " + employee[0].Department);
                Console.WriteLine("Title: " + employee[0].Title);
                Console.WriteLine("Hired Date: " + employee[0].HiredDate);
            }
            //}
            Console.WriteLine("\nPress any key to go back to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        // Update an existing employee in the database by Employee Id
        private async Task UpdateEmployeeAsync()
        {
            // variables for an Employee
            string firstName = "";
            string lastName = "";
            DateTime birthDate = DateTime.Now;
            int branchId = -1;
            string department = "";
            string title = "";
            DateTime hiredDate = DateTime.Now;

            int employeeId = -1;
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine("Enter the id of the employee to update:");
                    employeeId = int.Parse(Console.ReadLine());
                    loop = false;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid numerical value.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
            }
            // Get the employee current information
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri.ToString() + $"api/employee?Id={employeeId}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var employee = await response.Content.ReadFromJsonAsync<List<EmployeeDTO>>();

                // Get employee information
                if (employee.Count == 0)
                {
                    Console.WriteLine("\nNo employee with Id: {0} found.", employeeId);
                    Console.WriteLine("Press any key to the main menu.");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("\nEmployee Id: " + employee[0].Id);
                    Console.WriteLine("Name: " + employee[0].FirstName + " " + employee[0].LastName);
                    Console.WriteLine("Birthdate: " + employee[0].BirthDate);
                    Console.WriteLine("Department: " + employee[0].Department);
                    Console.WriteLine("Title: " + employee[0].Title);
                    Console.WriteLine("Hired Date: " + employee[0].HiredDate);
                }
                // Loop for user confirmation
                bool loop1 = true;
                while (loop1)
                {
                    Console.WriteLine("\nAre you sure you want to update this employee's information?");
                    Console.WriteLine("[1] - Yes");
                    Console.WriteLine("[2] - No");
                    string input = Console.ReadLine();
                    int value = -1;
                    if (int.TryParse(input, out value))
                    {
                        switch (int.Parse(input))
                        {
                            // Update employee
                            case 1:
                                // Loop for first name
                                bool loop2 = true;
                                while (loop2)
                                {
                                    Console.WriteLine("Enter first name:");
                                    firstName = Console.ReadLine();
                                    if (string.IsNullOrEmpty(firstName))
                                    {
                                        Console.WriteLine("Please enter a valid first name.\n");
                                        Console.WriteLine("Press enter to continue.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        loop2 = false;
                                    }
                                }
                                // Loop for last name
                                bool loop3 = true;
                                while (loop3)
                                {
                                    Console.WriteLine("Enter last name:");
                                    lastName = Console.ReadLine();
                                    if (string.IsNullOrEmpty(lastName))
                                    {
                                        Console.WriteLine("Please enter a valid last name.\n");
                                        Console.WriteLine("Press enter to continue.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        loop3 = false;
                                    }
                                }
                                // Loop for birthdate
                                bool loop4 = true;
                                while (loop4)
                                {
                                    Console.WriteLine("Enter birthdate (yyyy-mm-dd):");
                                    string temp = Console.ReadLine();
                                    if (!DateTime.TryParse(temp, out birthDate))
                                    {
                                        Console.WriteLine("Please enter a valid birthdate.\n");
                                        Console.WriteLine("Press enter to continue.");
                                        Console.ReadLine();
                                    }
                                    else if (DateTime.Parse(temp) < birthDate)
                                    {
                                        Console.WriteLine("Birthdate cannot be older {0}.", birthDate);
                                        Console.WriteLine("Press enter to continue.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        birthDate = DateTime.Parse(temp);
                                        loop4 = false;
                                    }
                                }
                                // Loop for branch id
                                bool loop5 = true;
                                while (loop5)
                                {
                                    Console.WriteLine("Enter branch id:");
                                    string temp = Console.ReadLine();
                                    if (!int.TryParse(temp, out branchId))
                                    {
                                        Console.WriteLine("Please enter a valid branch id.\n");
                                        Console.WriteLine("Press enter to continue.");
                                        Console.ReadLine();
                                    }
                                    else if (int.Parse(temp) == 0)
                                    {
                                        Console.WriteLine("Branch Id cannot be 0.");
                                        Console.WriteLine("Press enter to continue.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        branchId = int.Parse(temp);
                                        loop5 = false;
                                    }
                                }
                                // Loop for department
                                bool loop6 = true;
                                do
                                {
                                    Console.WriteLine("Enter department name:");
                                    department = Console.ReadLine();
                                    if (string.IsNullOrEmpty(department))
                                    {
                                        Console.WriteLine("Please enter a valid department name.\n");
                                        Console.WriteLine("Press enter to continue.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        loop6 = false;
                                    }
                                } while (loop6);
                                // Loop for title
                                bool loop7 = true;
                                do
                                {
                                    Console.WriteLine("Enter title:");
                                    title = Console.ReadLine();
                                    if (string.IsNullOrEmpty(title))
                                    {
                                        Console.WriteLine("Please enter a valid title.\n");
                                        Console.WriteLine("Press enter to continue.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        loop7 = false;
                                    }
                                } while (loop7);
                                // Ask for a new hired date
                                bool loop8 = true;
                                do
                                {
                                    Console.WriteLine("Enter a hired date (yyyy-mm-dd):");
                                    string date = Console.ReadLine();
                                    if (!DateTime.TryParse(date, out hiredDate))
                                    {
                                        Console.WriteLine("Please enter a valid date in the specified format.\n");
                                        Console.WriteLine("Press enter to continue.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        hiredDate = DateTime.Parse(date);
                                        loop8 = false;
                                    }
                                } while (loop8);

                                // Update the employee in the list
                                employee[0].FirstName = firstName;
                                employee[0].LastName = lastName;
                                employee[0].BirthDate = birthDate;
                                employee[0].BranchId = branchId;
                                employee[0].Department = department;
                                employee[0].Title = title;
                                employee[0].HiredDate = hiredDate;

                                HttpResponseMessage response1 = await httpClient.PutAsJsonAsync(_uri.ToString() + $"api/updateEmp?id={employeeId}", employee[0]);

                                response1.EnsureSuccessStatusCode();

                                Console.WriteLine("\nEmployee updated.");
                                loop1 = false;
                                break;
                            case 2:
                                Console.WriteLine("Employee not updated.");
                                loop1 = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid numerical value.");
                    }
                }
            }
            Console.WriteLine("\nPress any key to go back to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        // Delete an employee from the database by Employee Id
        private async Task DeleteEmployeeAsync()
        {
            int employeeId = -1;
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine("Enter the id of employee you want to delete:");
                    employeeId = int.Parse(Console.ReadLine());
                    loop = false;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid numerical value.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
            }

            // Get the employee information
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri.ToString() + $"api/employee?Id={employeeId}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var employee = await response.Content.ReadFromJsonAsync<List<EmployeeDTO>>();

                if (employee.Count == 0)
                {
                    Console.WriteLine("\nNo employee with Id: {0} found.", employeeId);
                    Console.WriteLine("Press any key to the main menu.");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("\nEmployee Id: " + employee[0].Id);
                    Console.WriteLine("Name: " + employee[0].FirstName + " " + employee[0].LastName);
                    Console.WriteLine("Birthdate: " + employee[0].BirthDate);
                    Console.WriteLine("Department: " + employee[0].Department);
                    Console.WriteLine("Title: " + employee[0].Title);
                    Console.WriteLine("Hired Date: " + employee[0].HiredDate);
                }

                // Loop for user confirmation
                bool loop1 = true;
                while(loop1)
                {
                    Console.WriteLine("\nAre you sure you want to remove this employee from the database?");
                    Console.WriteLine("[1] - Yes");
                    Console.WriteLine("[2] - No");
                    string input = Console.ReadLine();
                    int value = -1;
                    if (int.TryParse(input, out value))
                    {
                        switch (int.Parse(input))
                        {
                            case 1:     // Delete employee
                                request = new HttpRequestMessage(HttpMethod.Delete, _uri.ToString() + $"api/deleteEmp?Id={employeeId}");
                                request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

                                using (HttpResponseMessage response1 = await httpClient.SendAsync(request))
                                {
                                    response.EnsureSuccessStatusCode();

                                    if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                                    {
                                        throw new ArrayTypeMismatchException();
                                    }
                                    Console.WriteLine("Employee deleted.");
                                    loop1 = false;
                                }
                                break;
                            case 2:
                                Console.WriteLine("Employee not deleted.");
                                loop1 = false;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid numerical value.");
                    }
                }
            }
            Console.WriteLine("\nPress any key to go back to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }

        // Print out all locations in the database
        private async Task GetLocationsAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _uri.ToString() + "api/locations");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                var locations = await response.Content.ReadFromJsonAsync<List<LocationDTO>>();

                if (locations != null)
                {
                    Console.WriteLine("Locations: ");
                    foreach (var location in locations)
                    {
                        //Console.WriteLine("Id: " + location.Id);
                        Console.WriteLine("City: " + location.City);
                        Console.WriteLine("State: " + location.State);
                        Console.WriteLine("Country: " + location.Country);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No locations found.");
                }
            }
            Console.WriteLine("Press any key to return to the Main Menu.");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
