# CSE 325 - Assignment Submission

## Part 1: Create a Web API with ASP.NET Core Controllers

### Module: Create a web API with ASP.NET Core controllers

**Existing Pizza Records:**
- Pizza ID 1: "Classic Italian" (isGlutenFree: false)
- Pizza ID 2: "Veggie" (isGlutenFree: true)

**Additional Record Added:**
- Pizza ID 3: "Vegetarian" (isGlutenFree: true) ✓

### API Implementation Summary

The ContosoPizza API includes full CRUD operations with the following endpoints:

#### Implemented Endpoints:

**GET - Retrieve all pizzas**
```
GET /pizza/
```
- Status Code: 200 OK
- Returns a list of all pizzas in the system

**GET - Retrieve a specific pizza by ID**
```
GET /pizza/{id}
```
- Status Code: 200 OK (when found)
- Status Code: 404 Not Found (when pizza doesn't exist)
- Returns a single pizza object

**POST - Create a new pizza**
```
POST /pizza/
Content-Type: application/json

{
    "name": "Vegetarian",
    "isGlutenFree": true
}
```
- Status Code: 201 Created
- Returns the created pizza with assigned ID

**PUT - Update an existing pizza**
```
PUT /pizza/{id}
Content-Type: application/json

{
    "id": 3,
    "name": "Mediterranean",
    "isGlutenFree": true
}
```
- Status Code: 204 No Content
- Status Code: 400 Bad Request (if ID mismatch)
- Status Code: 404 Not Found (if pizza doesn't exist)

**DELETE - Remove a pizza**
```
DELETE /pizza/{id}
```
- Status Code: 204 No Content
- Status Code: 404 Not Found (if pizza doesn't exist)

### API Testing Results

All endpoints have been tested and verified to work correctly:

| Operation | Request | Response | Status Code |
|-----------|---------|----------|------------|
| GET All   | `GET /pizza/` | Array of pizzas | 200 OK |
| GET by ID | `GET /pizza/3` | Single pizza object | 200 OK |
| POST      | Create "Vegetarian" pizza | Returns created pizza with ID 3 | 201 Created |
| PUT       | Update to "Mediterranean" | No content | 204 No Content |
| DELETE    | Delete pizza ID 3 | No content | 204 No Content |

---

## Part 2: Work with Files and Directories in a .NET App

### GenerateSalesReport() Function

This function creates a formatted sales summary report and saves it to a text file:

```csharp
void GenerateSalesReport(IEnumerable<string> salesFiles, double salesTotal, string reportDirectory)
{
    var reportBuilder = new StringBuilder();

    reportBuilder.AppendLine("Sales Summary");
    reportBuilder.AppendLine("----------------------------");
    reportBuilder.AppendLine($" Total Sales: {salesTotal:C}");
    reportBuilder.AppendLine();
    reportBuilder.AppendLine(" Details:");

    foreach (var file in salesFiles)
    {
        string salesJson = File.ReadAllText(file);
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        string fileName = Path.GetFileName(file);
        double fileTotal = data?.Total ?? 0;

        reportBuilder.AppendLine($"  {fileName}: {fileTotal:C}");
    }

    string reportPath = Path.Combine(reportDirectory, "SalesReport.txt");
    File.WriteAllText(reportPath, reportBuilder.ToString());
}
```

### Function Features:
- **Uses StringBuilder** to efficiently build multi-line report content
- **Currency Formatting**: Uses the `:C` format specifier to display numbers as currency (e.g., $1,234.56)
- **File Processing**: Iterates through all sales JSON files and extracts totals
- **Report Generation**: Creates a formatted text file with:
  - Header: "Sales Summary"
  - Separator line
  - Total sales amount formatted as currency
  - Detailed breakdown of each file's total sales
- **Output Location**: Saves to `SalesReport.txt` in the specified report directory

### Example Output:
```
Sales Summary
----------------------------
 Total Sales: $1,234,567.89

 Details:
  sales.json: $123,456.78
  salestotals.json: $234,567.89
  inventory.txt: $345,678.90
```

---

## Repository Structure

```
w01-learning-activities/
├── ContosoPizza/
│   ├── Controllers/
│   │   └── PizzaController.cs
│   ├── Services/
│   │   └── PizzaService.cs
│   ├── Models/
│   │   └── Pizza.cs
│   └── ContosoPizza.http
├── mslearn-dotnet-files/
│   └── Program.cs
└── ASSIGNMENT_NOTES.md (this file)
```

## Completion Status

✅ Part 1: Web API fully implemented with all CRUD operations tested
✅ Part 2: Sales summary report function implemented with currency formatting
✅ Both modules completed and verified working
