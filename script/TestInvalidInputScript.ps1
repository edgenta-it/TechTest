# Define the base URL of API
$baseUrl = "https://localhost:7013/IO"

# Define the numerical input you want to convert
$inputNumber = "test invalid input"

# Combine the base URL and parameter
$url = $baseUrl + "?inputNumber=" + $inputNumber

# Make a GET request to the constructed URL
$result = Invoke-RestMethod -Uri $url -Method Get

# Output the result
$result