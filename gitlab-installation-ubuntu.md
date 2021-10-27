Enterprise edition:
------------------------------

lsb_release -a && ip r
vi /etc/hosts

127.0.0.1 localhost
10.170.1.94 example.gitlab.com gitlab

apt-get update && apt-get upgrade -y
apt-get install -y curl openssh-server ca-certificates tzdata perl postfix

curl -s https://packages.gitlab.com/install/repositories/gitlab/gitlab-ee/script.deb.sh | sudo bash
or curl -s https://packages.gitlab.com/install/repositories/gitlab/gitlab-ee/script.rpm.sh | sudo bash

apt-get install gitlab-ee

gitlab-ctl reconfigure
gitlab-ctl start
gitlab-ctl status

gitlab-rails console -e production

>> to reset root password

user = User.where(id: 1).first
user.password ='passw0rd'
user.password_confirmation ='passw0rd'
user.save!

http://10.170.1.94/



Community Edition:
-------------------------------
sudo apt update
sudo apt-get install -y curl openssh-server ca-certificates
sudo apt-get install -y postfix

curl -sS https://packages.gitlab.com/install/repositories/gitlab/gitlab-ce/script.deb.sh | sudo bash

sudo apt-get install gitlab-ce

>>If you want to set up using your server address, do the below
sudo EXTERNAL_URL="http://gitlabce.example.com" apt-get install gitlab-ce
or
sudo nano /etc/gitlab/gitlab.rb
external_url 'https://gitlab.example.com'

letsencrypt['enable'] = true
letsencrypt['contact_emails'] = ['admin@example.com'] # This should be an array of email addresses to add as contacts


sudo gitlab-ctl reconfigure

sudo ufw allow 80/tcp
sudo ufw allow 443/tcp
or
sudo ufw allow OpenSSH
sudo ufw allow http
sudo ufw allow https

gitlab-ctl start

https://your_gitlab_domain_or_server_IP

uninstall:

sudo apt-get remove gitlab-ce
sudo rm -rf /var/opt/gitlab
sudo pkill -f gitlab

sudo rm -rf /opt/gitlab
sudo rm -rf /etc/gitlab
sudo rm -rf /var/opt/gitlab