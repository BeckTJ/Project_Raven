#!/bin/sh

initdb -A "trust"

pg_ctl start

/usr/raven/import-data.sh

