FROM postgres

COPY ./DbBuild.sql /docker-entrypoint-initdb.d/

RUN mkdir -p /usr/raven
WORKDIR /usr/raven

COPY ./Data /usr/raven/

USER postgres
