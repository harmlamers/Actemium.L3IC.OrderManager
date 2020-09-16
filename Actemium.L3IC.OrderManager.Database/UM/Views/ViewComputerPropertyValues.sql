
CREATE VIEW [UM].[ViewComputerPropertyValues]
AS
SELECT        UM.Properties.Id AS PropertyId, UM.Properties.Name, UM.Properties.DefaultValue, UM.Properties.DataType, UM.ComputerPropertyValues.ComputerId, 
                         UM.ComputerPropertyValues.Value
FROM            UM.Properties LEFT OUTER JOIN
                         UM.ComputerPropertyValues ON UM.Properties.Id = UM.ComputerPropertyValues.PropertyId
WHERE        (UM.Properties.Type = 2)