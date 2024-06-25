import React from 'react';
import { Box, Divider, Typography } from '@mui/joy';

export default function OrderButton() {
  return (
    <Box
      className="cursor-pointer border w-2/5 border-gray-500 p-4 rounded-lg bg-green-200 hover:bg-green-300"
    >
      <Box className="flex items-center justify-between">
        <Typography component="h3" textAlign="left" level="h2">
          Заказ
        </Typography>
        <Divider orientation="vertical" className="h-5 mx-2" />
        <Typography component="h3" textAlign="right" level="h3">
          Дата создания заказа
        </Typography>
      </Box>
      <Box className="flex items-center justify-center mt-2">
        <Box className="px-2">Айдишник</Box>
        <Divider orientation="vertical" />
        <Box className="px-2">Дата создания заказа</Box>
      </Box>
    </Box>
  );
};