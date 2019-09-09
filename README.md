To run this as a docker container, execute these commands:

docker build -t aspnetapp LandrTest\.
docker run -d -p 8080:80 --name LandrTest_EmilePetrin aspnetapp

Then you can try the Get and Post to the port 8080

For the Post, it expect a json array in the body (ex: [ "107.159.19.143", "107.160.20.144", "::ffff:172.17.0.1", "108.160.20.144" ]).