import os
from tabulate import tabulate


class Project:
    def __init__(self, name):
        self.name = name
        self.file_count = 0
        self.line_count = 0
        self.blank_line_count = 0


ignore_folders = [".git", ".github", ".vs", "bin", "obj"]
file_extensions = [".cs"]
solution_name = os.path.basename(os.getcwd())
projects_folders = [d for d in os.listdir(os.getcwd()) if os.path.isdir(d) and d not in ignore_folders]
projects = []

for project_folder in projects_folders:
    project = Project(project_folder)
    for root, dirs, files in os.walk(project_folder):
        for file in files:
            if file.endswith(tuple(file_extensions)):
                with open(os.path.join(root, file), "r", encoding="utf-8") as f:
                    lines = f.readlines()
                    project.file_count += 1
                    project.line_count += len(lines)
                    project.blank_line_count += len([line for line in lines if line.strip() == ""])

    projects.append(project)

total = Project(solution_name)
for project in projects:
    total.file_count += project.file_count
    total.line_count += project.line_count
    total.blank_line_count += project.blank_line_count

projects.append(total)

table = []
for project in projects:
    table.append([project.name, project.file_count, project.line_count, project.blank_line_count])

print(tabulate(table, headers=["Project", "File Count", "Line Count", "Blank Line Count"], tablefmt="grid"))



