USE cse325project;

select m.name,m.id, u.username, m.date, m.description,m.courses_id from meetings m
join users_has_meetings um on m.id = um.Meetings_id
join users u on um.Users_ID = u.ID;


