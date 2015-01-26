update [ActionType]
set
	ParameterTemplate = '<ParameterTemplate xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <Parameter>
        <Name>hazcon</Name>
        <DisplayName>Hazerdous Condition</DisplayName>
        <DefaultValue>0</DefaultValue>
        <Description>This is a integer value used to set the hazerdous condition state type</Description>
        <UsePasswordCharacters>false</UsePasswordCharacters>
        <Hidden>false</Hidden>
    </Parameter>
</ParameterTemplate>'
where
	ActionTypeID = -23
	
update [Action]
set
	Parameter = '<ParameterTemplate>
    <Parameter>
        <Name>hazcon</Name>
        <Value>0</Value>
        <UsePasswordCharacters>false</UsePasswordCharacters>
    </Parameter>
</ParameterTemplate>',
	ParameterCache = '<hazcon>0</hazcon>'
where
	ActionID = 13
	
update [Action]
set
	Parameter = '<ParameterTemplate>
    <Parameter>
        <Name>hazcon</Name>
        <Value>1</Value>
        <UsePasswordCharacters>false</UsePasswordCharacters>
    </Parameter>
</ParameterTemplate>',
	ParameterCache = '<hazcon>1</hazcon>'
where
	ActionID = 14
	
update [Action]
set
	Parameter = '<ParameterTemplate>
    <Parameter>
        <Name>hazcon</Name>
        <Value>2</Value>
        <UsePasswordCharacters>false</UsePasswordCharacters>
    </Parameter>
</ParameterTemplate>',
	ParameterCache = '<hazcon>2</hazcon>'
where
	ActionID = 15