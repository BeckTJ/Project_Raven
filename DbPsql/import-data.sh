#!/bin/sh

psql -U postgres -a -f DbBuild.sql

psql -U postgres -a -f DataUpload.sql