# Loading Dependencies
add-pssnapin WebScrapingCmdlets

#[void][reflection.assembly]::LoadFrom("D:\work\NeuralStar\Services\EventService\bin\Debug\BusinessObject.dll");

# Powershell 2
Add-Type -Path "D:\work\NeuralStar\Services\EventService\bin\Debug\BusinessObject.dll"

# Create the stopwatch
$sw = New-Object System.Diagnostics.StopWatch
$sw.Start()

#get-web -Address "http://wordpress/wp-admin" -QueryParameters "log=admin&pwd=PasswordGoesHere" -ReGet true
$sitetext = get-web -Address "http://nerddinner/Dinners"

$sw.Stop()

$regex = [regex]"PlannedDinner"
$matches = $regex.Matches($sitetext)

write-host "Milliseconds:" $sw.Elapsed.Milliseconds.ToString()
write-host "Matches: " $matches.Count

#37B51B0C-F34F-E011-BBFC-005056C00008
#2034241003678558796

$measurement = [Double]$sw.Elapsed.Milliseconds
$sampleTime = Get-Date

$user = [AiMetrix.BusinessObject.Security.User]::Login("test", "test")

$nsobjectID = New-Object System.Guid("37B51B0C-F34F-E011-BBFC-005056C00008")
$collector = New-Object AiMetrix.BusinessObject.Performance.MeasurementCollector
$collector.AddPointMeasurement($nsobjectID, 2034241003678558796, $measurement, $sampleTime)

[void]$collector.Save()
[void][AiMetrix.BusinessObject.Security.User]::Logout();