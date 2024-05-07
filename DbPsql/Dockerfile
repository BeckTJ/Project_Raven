FROM postgres

COPY ./DbBuild.sql /docker-entrypoint-initdb.d/

RUN mkdir -p /usr/raven
WORKDIR /usr/raven

COPY ./Data /usr/raven/
COPY --chmod=765 ../../entrypoint.sh /usr/raven/
COPY --chmod=777 ../../import-data.sh /usr/raven/

USER postgres

EXPOSE 5432

