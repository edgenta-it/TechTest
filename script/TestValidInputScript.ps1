# Define the base URL of API
$baseUrl = "https://localhost:7203/api/IO"

# Define the numerical input you want to convert
$inputNumber = "123.45"

# Combine the base URL and parameter
$url = $baseUrl + "?inputNumber=" + $inputNumber

# Make a GET request to the constructed URL
$result = Invoke-RestMethod -Uri $url -Method Get

# Output the result
$result