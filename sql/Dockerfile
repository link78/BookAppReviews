FROM mcr.microsoft.com/mssql/server:2017-CU17-ubuntu

ENV ACCEPT_EULA=Y

ENV SA_PASSWORD=Marine7815@@

ENV MSSQL_PID Express

RUN mkdir -p /src/src/app

WORKDIR /src/src/app

COPY . ./

EXPOSE 1433

RUN chmod +x ./setup-db.sh
RUN chmod +x ./entrypoint.sh


CMD /bin/bash ./entrypoint.sh
