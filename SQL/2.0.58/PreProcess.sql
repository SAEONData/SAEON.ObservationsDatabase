Update Project set ProgrammeID = (select ID from Programme where Name = 'SAEON') where ProgrammeID is null