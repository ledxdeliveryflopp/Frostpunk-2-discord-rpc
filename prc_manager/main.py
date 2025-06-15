import sys
import requests


def parse_args() -> tuple:
    info_type: str = sys.argv[1]
    data: str = str(sys.argv[2])
    return info_type, data


def make_request():
    info_type, data = parse_args()
    request = requests.get(f'http://localhost:9381/api?info_type={info_type}&data={data}')
    if request.status_code == 200:
        print('success')
    else:
        print('error')


if __name__ == '__main__':
    make_request()
