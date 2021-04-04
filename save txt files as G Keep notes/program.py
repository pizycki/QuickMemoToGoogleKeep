import gkeepapi

keep = gkeepapi.Keep()
email = "xxxxxx@gmail.com"
pwd = "xxxx"
success = keep.login(email, pwd)

for i in range(1, 86):

    f = open("/mnt/c/Users/pawel/dev/Memos/Memo " + str(i) + ".txt", "r")
    content = f.read()

    note = keep.createNote("Memo " + str(i), content)
    keep.sync()