select meettitle Subject, convert(varchar,meetdate,101) StartDate, convert(varchar,meetdate,114) StartTime, 'True' [All Day Event],
meets.Notes Description, meets.LocationName + ' ' + isnull(meets.LocationAddress1, '') + ' ' + isnull(meets.LocationAddress2,'') Location
from Meets where yearid = 2018