REM Make event organiser
curl -X POST "https://localhost:44373/api/EventOrganisers" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userName\":\"xlin\",\"password\":\"password\",\"eventIDs\":\"\",\"name\":\"David Lin\",\"email\":\"email@email.com\"}"

REM Make event
curl -X POST "https://localhost:44373/api/Events" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"eventID\":0,\"employerLink\":\"https://tinyurl.com/yxaxeu7j\",\"userLink\":\"https://tinyurl.com/uoos952j\",\"status\":\"peri\",\"helpLink\":\"https://tinyurl.com/fdijg4ii\",\"name\":\"Meet and Greet\",\"description\":\"Devs Society Meet and Greet\"}"    

REM Make queue for a pool
curl -X POST "https://localhost:44373/api/Queues" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"userIDs\":\"\"}"

REM Make pool for booths
curl -X POST "https://localhost:44373/api/Pools" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"booths\":\"\",\"queueID\":1}"

REM Make Interviewer
curl -X POST "https://localhost:44373/api/Interviewers" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"desc\":\"Senior Software Developer at Microsoft\",\"name\":\"Newton\",\"eventID\":0,\"email\":\"newton@microsoft.com\"}"

REM Make booth
curl -X POST "https://localhost:44373/api/Booths" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"occupied\":false,\"interviewerID\":0,\"payload\":\"https://tinyurl.com/yxaxeu7j\",\"currentUser\":0,\"isActive\":true,\"eventID\":0}"

REM Add booth to pool
REM API CALL

REM Make users
curl -X POST "https://localhost:44373/api/Users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"name\":\"David Lin\",\"eventID\":0,\"email\":\"wsydgx@hotmail.com\"}"
curl -X POST "https://localhost:44373/api/Users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"name\":\"Celine Harrison\",\"eventID\":0,\"email\":\"Harrison@hotmail.com\"}"
curl -X POST "https://localhost:44373/api/Users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"name\":\"Ryan Bircham\",\"eventID\":0,\"email\":\"Bircham@gmail.com\"}"
curl -X POST "https://localhost:44373/api/Users" -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"name\":\"Liam Scott-Russell\",\"eventID\":0,\"email\":\"Scott-Russell@hotmail.com\"}"

REM Queue user up