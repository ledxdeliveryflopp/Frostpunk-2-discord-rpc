import uvicorn
from fastapi import FastAPI

app = FastAPI()


@app.get('/api')
async def read_item(info_type: str, data: str):
    print(f'type: {info_type}, data: {data}')
    return {'type': info_type, 'data': data}


if __name__ == '__main__':
    uvicorn.run(app=app, host='localhost', port=9381)
