import sys


def parse_args() -> tuple:
    info_type: str = sys.argv[1]
    data: str = str(sys.argv[2])
    return info_type, data


def write_file():
    info_type, data = parse_args()
    with open('data.txt', 'w+') as file:
        file.write(f'info_type\n')
        file.write(data)


if __name__ == '__main__':
    write_file()
