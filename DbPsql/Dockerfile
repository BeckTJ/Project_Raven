FROM postgres

RUN mkdir -p /usr/raven
WORKDIR /usr/raven

COPY ./Data /usr/raven/

EXPOSE 5432

CMD /bin/bash ./entrypoint.sh