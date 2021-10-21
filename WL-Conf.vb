WebLogic-Config && Installation:
------------------------------------
Change the host file
Vi /etc/hosts
192.168.**.** teachapex.localdomain teachapex

*********Check Pre-Requisites for DB 12C***********

yum install oracle-database-server-12cR2-preinstall -y

to check settings /sbin.sysctl -p or /sbin/sysctl -p /etc/sysctl.d/98-oracle.Conf

Add the following lines to  file " /etc/security/limits.d/oracle-database-server-12cR2-preinstall.conf" 

oracle soft nofile 1024
oracle hard nofile 65536
oracle soft nproc 16384
oracle hard nproc 16384
oracle soft stack 10240
oracle hard stack 32768
oracle soft memlock 134217728
oracle hard memlock 134217728


RHEL6 or RHEL7:
----------------

yum install binutils -y
yum install compat-lincapl -y
yum install compat-libstdc++-33 -y
yum install compat-libstdc++-33.i686 -y

yum install glibc -y
yum install glibc.i686 -y
yum install glibc-devel -y
yum install glibc-devel.i686 -y

yum install ksh -y
yum install libaio -y
yum install libaio.i686 -y
yum install libaio-devel -y
yum install libaio-devel.i686 -y

yum install libX11 -y
yum install libX11.i686 -y
yum install libXau -y
yum install libXau.i686 -y
yum install libXi -y
yum install libXi.i686 -y
yum install libXtst -y
yum install libXst.i686 -y

yum install libgcc -y
yum install libgcc.i686 -y

yum install libstdc++ -y
yum install libstdc++.i686 -y
yum install libstdc++-devel -y
yum install libstdc++-devel.i686 -y

yum install libxcb -y
yum install libxcb.i686 -y

yum install make -y
yum install nfs-utils -y
yum install net-tools -y
yum install smartmontools -y
yum install sysstat -y
yum install unixODBC -y
yum install unixODBC-devel -y


groupadd -g 54321 oinstall
groupadd -g 54322 dba
groupadd -g 54323 oper
groupadd -g 54324 backupdba
groupadd -g 54325 dgdba
groupadd -g 54326 kmdba
groupadd -g 54327 asmdba
groupadd -g 54328 asmoper
groupadd -g 54329 asmadmin
groupadd -g 54330 racdba


groupadd -g 1501 oinstall
groupadd -g 1502 dba
groupadd -g 1503 oper
groupadd -g 1504 backupdba
groupadd -g 1505 dgdba
groupadd -g 1506 kmdba

useradd -u 1501 -g oinstall -G dba,oper,backupdba,dgdba,kmdba,racdba oracle

mkdir -p /u01/app/oracle/product/19.3.0/dbhome_1
mkdir -p /u02/oradata
chown -R oracle:oinstall /u01 /u02
chmod -R 775 /u01 /u02

passwd oracle

Set secure Linux to permissive by editing "/etc/selinux/config" file, making sure the SELINUX flag is set as follows.

SELINUX=permissive

# setupc (to disable filewall)

systemctl stop firewalld
systemctl diable firewalld

df -hT (to check space)

mkdir -p /u01/app/oracle/product/12.2.0.1/db_1
chown -R oracle:oinstall /u01
chmod -R 775 /u01

su - oracle
cd ~
cp .bash_profile bash_profile.bkup

*******Oracle Settings************

vi .bash_profile

TMP=/tmp; export TMP
TMPDIR=\$TMP; export TMPDIR

ORACLE_HOSTNAME=teachapex.localdomain; export ORACLE_HOSTNAME
ORACLE_UNQNAME=orcl; export ORACLE_UNQNAME
ORACLE_BASE=/u01/app/oracle; export ORACLE_BASE
ORACLE_HOME=\$ORACLE_BASE/product/12.2.0.1/db_1; export ORACLE_HOME
ORACLE_SID=orcl; export ORACLE_SID

PATH=/usr/sbin:$PATH; export PATH
PATH=\$ORACLE_HOME/bin;$PATH; export PATH

LD_LIBRARY_PATH=$ORACLE_HOME/lib:/lib:/usr/lib; export LD_LIBRARY_PATH
CLASSPATH=$ORACLE_HOME/jlib:$ORACLE_HOME/rdbms/jlib; export CLASSPATH

******************************************************************************************

Install Oracle 12c database 

dowanload oracle 12c database zip file, copy to VM and extarct the zip file
location cd \linux\Oracle\12c\DB\64bit\












