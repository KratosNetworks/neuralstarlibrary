$eventLogMessage = "Hey! This is from the script:     "

foreach($key in $EventData.keys) {
    $eventLogMessage = $eventLogMessage + "Key: " + $key + "     Data: " + $EventData[$key] + "     "
}

Write-EventLog -LogName Application -EntryType Error -Source dvDataService -EventId 6 -Message $eventLogMessage