#!/bin/bash
set -e

# Cleanup potential old files
[ -d "./tooling" ] && rm -rf ./tooling

# Initial setup of variables
libary_name="