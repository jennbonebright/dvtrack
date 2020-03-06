insert into marks (year, event, inches, gender, grade, athletename)
select 2016, 'PV', (12*12)+9, 'F', 12, 'Aliya Simpson'

	insert into marks (year, event, Time, gender, grade, athletename)
	select 2016, '800', '1980-12-31 00:02:15.17', 'F', 11, 'Baylee Jones'

select * from marks where event = '800'

select * from statemeets

update marks set event = '300H' where markid = 1378;

delete from marks where markid = 1381

