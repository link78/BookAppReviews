FROM mcr.microsoft.com/mssql/server:2017-latest

ENV ACCEPT_EULA=Y

ENV SA_PASSWORD=Marine7815@@

WORKDIR /src

COPY . ./

RUN chmod +x ./setup-db.sh
RUN chmod +x ./entrypoint.sh

CMD bash ./entrypoint.sh