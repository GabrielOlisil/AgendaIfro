docker run -dp 3306:3306 --name mariadb-agenda --env MARIADB_ROOT_PASSWORD=my-secret-pw --env MARIADB_DATABASE=agenda_app mariadb:11.7.1-noble-rc
